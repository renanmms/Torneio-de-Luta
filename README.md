# Torneio de Luta

O projeto Torneio de Luta foi feito com ASP.NET Core MVC e C#, consiste em uma tela com 37 lutadores onde é selecionado 16 lutadores para participar do torneio e descobrir quem é o campeão baseado nos critérios propostos para um teste técnico em um processo seletivo.

## Requisitos Necessários:

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Visual Studio Community](https://visualstudio.microsoft.com/pt-br/vs/community/) ou [Visual Studio Code]()

## Como rodar o projeto:

### Visual Studio Community:

1. Instalar os softwares listados nos [Requisitos Necessários](https://github.com/renanmms/Torneio-de-Luta/edit/master/README.md#requisitos-necess%C3%A1rios).
2. Abrir uma nova janela do Visual Studio Community e ir na opção de **Clonar um repositório**.
3. Preencher o campo **Local do repositório** com o link do repositório.

```
https://github.com/renanmms/Torneio-de-Luta.git
```

4. Abrir o **Gerenciador de Soluções** indo em **Exibir**, e em seguida abrir a solução.
5. Rodar o projeto indo na opção **Depurar** e **Iniciar Depuração**, ou aperte a tecla de atalho **F5**.

### Visual Studio Code:

1. Abrir uma nova janela do Visual Studio Code
2. Abrir o menu **Explorer** indo em **View**, ou usar a tecla de atalho `Ctrl+Shift+E`
3. Ir na opção de **Clone Repository**
4. Abrir o terminal indo **View** e em seguida **Terminal**, ou usar a tecla de atalho `Ctrl+'`
5. Rodar o comando abaixo para executar o projeto

```bash
dotnet run
```
## Como funciona o projeto:

A tela inicial possui 37 lutadores da qual é possível selecionar somente 16 deles, para cada um dos lutadores é mostrado os seguintes dados:

- Nome
- Idade
- Quantidade de Lutas
- Vitórias
- Derrotas
- Quantidade de Artes Marciais

![image](https://user-images.githubusercontent.com/41764187/190203116-2a0d6188-0ba1-465e-ac3a-27a1e7280e08.png)

Para selecionar os Lutadores que irão participar do Torneio, basta clicar nas caixas de seleção que ficam logo abaixo do nome do Lutador, após selecionado os participantes, clicar no botão **Iniciar Torneio**.

O campeão do torneio é definido após uma série de lutas entre os lutadores, e todos os lutadores possuem uma classificação (oitavas, quartas de final, semi final e final), o vencedor de uma luta é definido pela sua porcentagem de vitórias que é `( nº de vitórias / nº total de lutas ) * 100`, se houver empate deve definir o desempate pelo lutador com maior quantidade de artes marciais, senão é definido pelo lutador com maior número de lutas, logo a classificação do lutador é alterada dependendo de sua classificação atual.

Por fim, é mostrado a tela com o campeão do torneio, e logo abaixo tem a opção de **Jogar Novamente**.

![image](https://user-images.githubusercontent.com/41764187/190055402-a7c649cb-3609-45f4-b86d-6cfdc7daa3d8.png)
