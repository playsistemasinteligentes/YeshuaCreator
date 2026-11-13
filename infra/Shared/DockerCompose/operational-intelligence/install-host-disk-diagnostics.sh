#!/usr/bin/env bash
set -euo pipefail

SOURCE_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
REPORT_DIR="/root/YeshuaStorage/volatile/operational-intelligence/host-diagnostics"
install -d -m 0755 -o root -g root /opt/yeshua-host-diagnostics "$REPORT_DIR"
install -m 0755 -o root -g root "$SOURCE_DIR/host-disk-usage.py" /opt/yeshua-host-diagnostics/host-disk-usage.py

cat > /etc/systemd/system/yeshua-host-disk-usage.service <<'EOF'
[Unit]
Description=Yeshua host disk usage metadata
After=docker.service

[Service]
Type=oneshot
User=root
ExecStart=/usr/bin/python3 -B /opt/yeshua-host-diagnostics/host-disk-usage.py
Nice=19
IOSchedulingClass=idle
NoNewPrivileges=true
TimeoutStartSec=150
EOF

cat > /etc/systemd/system/yeshua-host-disk-usage.timer <<'EOF'
[Unit]
Description=Refresh Yeshua host disk usage every fifteen minutes

[Timer]
OnBootSec=2min
OnUnitActiveSec=15min
AccuracySec=1min
Unit=yeshua-host-disk-usage.service

[Install]
WantedBy=timers.target
EOF

systemctl daemon-reload
systemctl enable --now yeshua-host-disk-usage.timer
systemctl start yeshua-host-disk-usage.service
