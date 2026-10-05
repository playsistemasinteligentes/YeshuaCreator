# Certificados ICP-Brasil

Certificados publicos usados pelas imagens Docker do Yeshua para confiar nos
endpoints fiscais da SEFAZ que usam a cadeia ICP-Brasil.

Arquivos atuais:

- `icp-brasil-v10.crt`: Autoridade Certificadora Raiz Brasileira v10.
- `ac-soluti-ssl-ev-g4.crt`: intermediaria AC SOLUTI SSL EV G4.

Esses arquivos sao copiados para `/usr/local/share/ca-certificates/icp-brasil`
durante o build das imagens e registrados com `update-ca-certificates`.

Nao baixar esses certificados durante o build: o build precisa ser
deterministico e nao depender da disponibilidade do site emissor no momento do
deploy.
