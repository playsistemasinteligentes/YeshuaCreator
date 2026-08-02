apos ubunto server estar instalado  executar 
sudo apt update && sudo apt install -y curl && \
sudo curl -sL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/infra/bootstraps/setup.sh | sudo bash


certificado
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-cert.sh | bash



deploy 

curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash


roda em segundo plano 
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash" > /root/deploy.log 2>&1 &

ve rodando em segundo plano 
tail -f /root/deploy.log


logs aotomaticos 
docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml logs --tail=100 -f --timestamps





