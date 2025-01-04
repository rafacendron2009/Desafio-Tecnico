Especificação para Execução do Projeto
Para rodar este projeto, siga os passos abaixo:

1. Clonar o Repositório
Primeiramente, clone o repositório do GitHub:

bash
Copiar código
git clone https://github.com/rafacendron2009/Desafio-Tecnico.git

2. Acessar a Branch feature/Api
Após clonar o repositório, acesse a branch feature/Api:

bash
Copiar código
cd Desafio-Tecnico
git checkout feature/Api

3. Construir a Imagem Docker
Dentro do diretório do projeto, execute o comando abaixo para construir a imagem Docker:

bash
Copiar código
docker build -t thunders .

4. Rodar o Docker
Após construir a imagem, execute o seguinte comando para rodar o container em segundo plano, mapeando a porta 5000 do container para a porta 5000 da sua máquina local:

bash
Copiar código
docker run -d -p 5000:5000 --name thunders thunders
O programa estará acessível através de http://localhost:5000.


5. Testando a API
Agora, você pode acessar a API rodando no Docker utilizando as rotas configuradas.
http://localhost:5000/swagger/index.html
