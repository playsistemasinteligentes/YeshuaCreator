apos ubunto server estar instalado  executar 
sudo apt update && sudo apt install -y curl && \
sudo curl -sL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/bootstraps/setup.sh | sudo bash


certificado
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/Devops/infra/bootstraps/setup-cert.sh | bash



deploy 

curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/Devops/infra/docker/deploy.sh | bash


segundo plano 

nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/Devops/infra/docker/deploy.sh | bash" > /root/deploy.log 2>&1 &
tail -f /root/deploy.log



