Configuração para criação de tabela no banco:

No projeto TesteLab temos o Web.config

Temos o trecho de código onde está comentado sobre o servidor;
Nesse trecho temos o seguinte banco associado:
Source=DESKTOP-V5SLNIS\VICTORSQL;

Substituir o banco para o banco local da maquina onde será executado.

Após isso entre no Console do Gerenciador de Pacotes e insira o comando:

Update-Database

Com isso basta apertar enter que o banco será criado em sua base de dados.


