apos ubunto server estar instalado  executar 
sudo apt update && sudo apt install -y curl && \
curl -sL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/bootstraps/setup.sh | bash


certificado
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/Devops/infra/bootstraps/setup-cert.sh | bash



deploy 

curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/Devops/infra/docker/deploy.sh | bash

           



