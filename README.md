# Exercício Api - Medieval Autobattler

Criar um jogo chamado Medieval Autobattler

Regras do jogo:

- Batalha entre o jogador e um inimigo (NPC)
- Antes da partida, cada jogador escolhe um deck com 5 cartas
- Após dar o play, a batalha ocorre automaticamente
- O jogo embaralha cada deck separadamente
- O jogo distribui na parte de cima da mesa uma linha com 5 cartas do npc
- O jogo distribui na parte de baixo da mesa uma linha com 5 cartas do jogador
- As cartas da mesma coluna batalham entre si
- Na batalha, a carta que tiver o maior Poder vence
- Cada batalha ganha rende 1 ponto
- O jogador com mais pontos pontos vence o jogo e ganha 1 moeda de ouro

Atributos da carta

- **Poder:** número de 0 a 9
- **Vantagem (bônus de poder):** número de 0 a 9
- **Tipo:** Archer, Spearman, Cavalry

Poder bônus em combate (pedra-papel-tesoura)

- Archer > Spearman (Archer recebe Poder bônus igual sua Vantagem contra Spearman)
- Spearman > Cavalry (Spearman recebe Poder bônus igual sua Vantagem contra Cavalry)
- Cavalry >  Archer  (Cavalry recebe Poder bônus igual sua Vantagem contra Archer)

# Requisitos da Aplicação

### ETAPA 1 - Funções do Administrador

- Criar cartas
    - Nome, Poder, Vantagem, Tipo, Nível (poder + vantagem)/2
- Editar cartas
    - Nome, Poder, Vantagem, Tipo
- Remover Cartas
- Cadastrar um NPC
    - Nome, Descrição
    - Associar 5 cartas ao NPC
- Editar um NPC
    - Nome, Descrição
    - Associar 5 cartas ao NPC
- Nível do npc é a média do nível de suas cartas
- Excluir um NPC

### Etapa 2 - Funções do Jogador

- Criar novo save
    - Associar um nome ao save
    - Um novo save começa com 1 deck padrão com 5 cartas as quais o poder + vantagem sao menores que 5
- Ver estatísticas: nome do save, ouro, nrº de partidas, nº derrotas, nº vitórias, nº pacotes comprados, nível do jogador
    - O nível do jogador é igual ao nível do maior NPC que conseguiu vencer
- Visualizar todas cartas adquiridas incluíndo as quantidades
- Listar todo os seus decks
- Criar um deck informando um nome e 5 cartas
- Editar um deck informando um novo nome e 5 cartas
- Apagar um deck

### Etapa 3 - Partida

- O jogo deve escolher aleatoriamente um NPC com nível no máximo 1 número maior que o nível do jogador
- O jogador saberá o nome do NPC antes de iniciar sua partida (mas não sabe as cartas)
- O jogador deverá escolher o seu deck
- O jogo deve informar o resultado da partida:
    - Como ficaram as cartas na mesa (5x5)
    - Quantos pontos o jogador e o NPC fizeram
    - Quem foi o vencedor
    - Como deve ficar o nível do jogador
    - Quantas moedas de ouro devem ser adicionadas ao jogador (1 de ouro)

### Etapa 4 - Progresso

- Abrir um booster de cartas: Custa 5 de ouro e vem 3 cartas aleatórias
- Ao derrotar todos os npcs que existem adicionar uma medalha na sessão de estatísticas
- Ao colecionar todas as cartas, adicionar uma medalha na sessão de estatísticas
