## 🚀 Provisionamento do Servidor

### 1. Setup inicial (novo VPS Ubuntu)

sudo apt update && sudo apt install -y curl && \
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/bootstraps/setup.sh | bash" > /root/setup.log 2>&1 &

tail -f /root/setup.log

### 3. Emitir certificado SSL
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/bootstraps/setup-cert.sh | bash" > /root/setup-cert.log 2>&1 &

tail -f /root/setup-cert.log




agora é fazer um deploy normal 