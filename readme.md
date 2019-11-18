Algumas considerações sobre o projeto. 

O presente projeto é parte de um processo seletivo de uma empresa em que me 
foi solicitado o consumo de dados a partir de um CSV. Esse arquivo continha 
informações sobre as escolas municipais de Porto Alegre e instituições de 
ensino conveniadas à Prefeitura, onde poderiam ser encontradas informações 
básicas, como localização da instituição e meios de contato. 

Para desenvolver o projeto, solicitaram que eu pensasse em uma pessoa que 
não conhecia o lugar para onde estava se mudando e que precisasse encontrar 
uma escola para colocar o seu filho. Tendo isso em mente, me coloquei no lugar 
dessa pessoa que  provavelmente não conheceria o nome da escola candidata, muito 
menos a sua localização. Então, por esse motivo, embora não tivesse sido solicitado 
dessa forma, resolvi fazer a busca pelo raio de interesse da pessoa, onde ela poderia 
fazer a busca da escola a partir das proximidades de seu lar, tendo em vista que esse 
é um lugar conhecido. 

As informações contidas dentro do CSV não condizem com a realidade demonstrada na 
projeção do Google Maps. Poderá ser notada algumas discrepâncias entre o que o 
Google Maps assinala e o que a Prefeitura representou espacialmente (acredito que 
isso ocorreu porque o CSV da prefeitura continha 5 dígitos decimais a menos - na maioria 
das vezes - comprometendo em grande medida a fidelização dos dados a realidade). Em muitos 
casos ocorreu que a representação espacial (a coordenada geográfica em que a escola estaria 
presente), email, site não estivessem presentes. No caso do Site, resolvi não usar, pois poucas 
escolas tinham a URL (de mil registros em torno de 100 tinham o site, inclusive extremamente 
desatualizado). De um modo geral, o CSV continha muitas informações incompletas, ou que não 
poderiam ser utilizadas, por esse motivo, dos mil registros que estavam expostos, apenas foram 
utilizados em torno de 315, o que é uma lástima, sendo um dado de extrema importância para a 
sociedade em geral. 

A única funcionalidade que eu não consegui implementar era o traçar a rota, que por falta de tempo 
e um pouco de conhecimento, me impediram de realizar a atividade por completo. 
Posteriormente, acredito que posso pegar o projeto novamente e fazer a parte da implementação que 
resta para concluir o projeto. 

Sobre as tecnologias utilizadas, começando pela guarda de dados, optou-se por fazer uso do banco de dados 
embarcado SQLite por causa da simplicidade de uso. No front, optou-se por utilizar Bootstrap na sua versão 4, 
JQuery/AJax, para manipulação de dados e configurações pertinentes ao front. Por fim, se resolveu utilizar o 
Azure, serviço de nuvem para Deployar a aplicação. 

Repositório no Git: https://github.com/DCommicsBP/dream-learning
Endereço da aplicação: https://dreamlearning20191118030836.azurewebsites.net/
