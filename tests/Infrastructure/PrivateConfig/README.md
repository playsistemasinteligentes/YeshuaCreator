# Regressão de configuração privada

Executar pela raiz: `python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -v`.
O loader de produção não tem flag de teste e suas verificações não são alteradas.
Só se usam dados sintéticos. Nunca apontar fixtures aos arquivos privados do operador.

## Runner com filesystem real

Por padrão os testes de arquivos usam o home do runner. Pode-se selecionar um
diretório privado **fora do checkout** com `YESHUA_PRIVATE_TEST_ROOT`. Isso não
muda HOME, não cria/autoriza uma exceção no loader e não ajusta permissões do host.
O diretório e todos os ancestrais devem passar pelas mesmas verificações reais
de dono/modo/symlink do loader; arquivos 0600 e diretórios privados 0700.
`/tmp` com ancestral gravável por terceiros e caminhos dentro do repositório são
recusados. Não mudar suas permissões para satisfazer a suíte.

Exemplo em runner Linux já preparado pelo operador:

```sh
YESHUA_PRIVATE_TEST_ROOT=/caminho-privado-do-runner \
python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -v
```

Esse é o modo necessário para aprovar a integração positiva com permissões reais.
Em Windows usar o runner nativo com PowerShell e executar os testes de ACL/launcher;
`pwsh` instalado no Linux não equivale a validar ACLs do Windows.

## Unidade em runner restrito

Se não há caminho real autorizado que satisfaça o loader, existe modo **explícito**
de filesystem sintético para os grupos de testes de arquivos/configuração:

```sh
python3 -m venv /tmp/yeshua-private-tests
/tmp/yeshua-private-tests/bin/pip install --no-cache-dir -r tests/Infrastructure/PrivateConfig/requirements-test.txt
YESHUA_PRIVATE_TEST_FILESYSTEM=virtual \
/tmp/yeshua-private-tests/bin/python -m unittest discover -s tests/Infrastructure/PrivateConfig -v
```

`pyfakefs` modela um home privado em memória e expõe somente o exemplo público
JSON como fixture de leitura. O módulo real do loader executa suas próprias
verificações nesse modelo; não são mockados `validate_access`, `write_new_json`,
`read_json` ou o guard de localização como solução para as restrições do runner.
Mocks pontuais já existentes de regras específicas dos testes permanecem.
O caminho legado de Memórias é sempre uma fixture ausente; testes de cofre
existente fornecem a própria fixture. Nenhuma leitura do cofre real é necessária.

O adaptador só no modo virtual corrige uma divergência de `fake_os.open` 6.3.2:
ao abrir um arquivo existente com O_RDONLY ele reaplica o modo padrão, enquanto
POSIX conserva as permissões. Preserva-se o modo existente e os checks
O_NOFOLLOW/O_EXCL; um teste verifica a conservação de bytes/0600 e outros negam
arquivo legível por terceiros e symlink. Não confundir isso com alterar chmod
do loader ou corrigir permissões reais. [Uso oficial de pyfakefs](https://pytest-pyfakefs.readthedocs.io/en/latest/usage.html).

`PhysicalSandboxGuardsTests` continua no filesystem **real**, mesmo nesse modo,
e prova que checkout e ancestral temporário inseguro seguem recusados antes de
gravar o documento. A aprovação do modo virtual é de unidade; **não aprova a
integração positiva de filesystem/ACL real** e não oculta esse bloqueio.
Dependência ausente/modo inválido produz erro, sem skip ou fallback automático.

## Compose e skips

Para validar somente modelos, definir `YESHUA_TEST_COMPOSE` com o caminho absoluto
do Compose standalone verificado, ou instalar a CLI no runner. O teste executa
apenas `config --quiet` com dados sintéticos, sem daemon, build, pull ou start.
Não precisa publicar serviços ou acessar o socket Docker. Sem CLI há um skip
explícito. Seis outros skips em Linux são intencionais: ACL Windows (um) e
launcher Windows (cinco); concluir essa cobertura no SO nativo.
