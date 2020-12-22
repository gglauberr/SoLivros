using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoLivros.DataAccess.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritos_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_LivroId",
                table: "Favoritos",
                column: "LivroId");

            migrationBuilder.Sql(livrosUp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Livros");
        }

        private readonly string livrosUp = $@"
            INSERT INTO Livros (Nome, Autor, Imagem, Descricao) VALUES
            ('Harry Potter e a Pedra Filosofal', 'J. K. Rowling', 'https://m.media-amazon.com/images/I/91melOnzGDL._AC_UL320_.jpg', 'Quando virou o envelope, com a mão trêmula, Harry viu um lacre de cera púrpura com um brasão; um leão, uma águia, um texugo e uma cobra circulando uma grande letra ""H"".'),
            ('Harry Potter e o Calice de Fogo', 'J. K. Rowling', 'https://m.media-amazon.com/images/I/511p8jnsATL.jpg', 'Harry volta para a Escola de Magia e Bruxaria de Hogwarts para cursar a quarta série. Para surpresa de todos não haverá a tradicional Copa Anual de Quadribol entre Casas. Será substituída pelo Torneio Tribuxo, uma competição amistosa entre as três maiores escolas européias de bruxaria.'),
            ('Harry Potter e a Ordem da Fenix', 'J. K. Rowling', 'https://m.media-amazon.com/images/I/41I1NK83piL.jpg', 'Harry não é mais um garoto. Aos 15 anos, continua sofrendo a rejeição dos Dursdley, sua estranhíssima família no mundo dos ""trouxas"". Também continua contando com Rony Weasley e Hermione Granger, seus melhores amigos em Hogwarts, para levar adiante suas investigações e aventuras. Neste quinto livro da saga'),
            ('Harry Potter e as Reliquias da Morte', 'J. K. Rowling', 'https://m.media-amazon.com/images/I/81rvO7xcJOL._AC_UL320_.jpg', 'Harry Potter e as relíquias da morte, de J.K. Rowling, é o sétimo e último livro da série. Voldemorte está cada vez mais forte e Harry Potter precisa encontrar e aniquilar as Horcruxes para enfraquecer o lorde e poder enfrentálo. Nessa busca desenfreada, contando apenas com os amigos Rony e Hermione, Harry descobre as Relíquias da Morte, que serão úteis na batalha do bem contra o mal.'),
            ('Harry Potter e a Camara Secreta', 'J. K. Rowling', 'https://images-na.ssl-images-amazon.com/images/I/51SnGLrrJcL._SX346_BO1,204,203,200_.jpg', 'Depois de férias aborrecidas na casa dos tios trouxas, está na hora de Harry Potter voltar a estudar. Coisas acontecem, no entanto, para dificultar o regresso de Harry. Persistente e astuto, o herói não se deixa intimidar pelos obstáculos e, com a ajuda dos fiéis amigos Weasley, começa o ano letivo na Escola de Magia e Bruxaria de Hogwarts. As novidades não são poucas.'),
            ('Harry Potter e o Prisioneiro de Azkaban', 'J. K. Rowling', 'https://images-na.ssl-images-amazon.com/images/I/41kT95iZ81L._SX346_BO1,204,203,200_.jpg', 'As aulas estão de volta à Hogwarts e Harry Potter não vê a hora de embarcar no expresso a vapor que o levará de volta à escola de bruxaria. Mais uma vez suas férias na rua dos Alfeneiros foi triste e solitária. Com muita ação, humor e magia, Harry Potter e o prisioneiro de Azkaban traz de volta o gigante atrapalhado Rúbeo Hagrid, o sábio diretor Alvo Dumbledore, a exigente professora de transformação Minerva MacGonagall e o novo mestre Lupin, que guarda grandes surpresas para Harry.'),
            ('A Guerra dos Tronos', 'George R. R. Martin', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12707349/1008977758.jpg?v=637154273585700000', 'A guerra dos tronos é o primeiro livro da série best-seller internacional As Crônicas de Gelo e Fogo, que deu origem à adaptação de sucesso da HBO, Game of Thrones. O verão pode durar décadas. O inverno, toda uma vida. E a guerra dos tronos começou. Como Guardião do Norte, lorde Eddard Stark não fica feliz quando o rei Robert o proclama a nova Mão do Rei. Sua honra o obriga a aceitar o cargo e deixar seu posto em Winterfell para rumar para a corte, onde os homens fazem o que lhes convém, não o que devem... e onde um inimigo morto é algo a ser admirado. Longe de casa e com a família dividida, Eddard se vê cada vez mais enredado nas intrigas mortais de Porto Real, sem saber que perigos ainda maiores espreitam a distância. Nas florestas ao norte de Winterfell, forças sobrenaturais se espalham por trás da Muralha que protege a região. E, nas Cidades Livres, o jovem Rei Dragão exilado na Rebelião de Robert planeja sua vingança e deseja recuperar sua herança de família: o Trono de Ferro de Westeros. “A guerra dos tronos é a maior obra de fantasia desde que Bilbo encontrou o Anel.” — SF Reviews'),
            ('A Furia Dos Reis', 'George R. R. Martin', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12106268/1002912379.jpg?v=637142237386570000', 'Nesta emocionante sequência de A guerra dos tronos, George R. R. Martin cria uma obra incomparável. A fúria dos reis nos transporta para um mundo de festas e vinganças, feitiçaria e disputas, diferente de tudo que já foi feito. Um cometa da cor de fogo e sangue corta os céus. E, da antiga cidadela de Pedra do Dragão às costas áridas de Winterfell, reina o caos. Em A fúria dos reis, seis facções disputam o controle de uma terra dividida e o direito de ocupar o Trono de Ferro de Westeros – e estão dispostos a encarar tempestades, levantes e guerras para isso. Nesta história, irmão trama contra irmão e os mortos se levantam para caminhar pela noite. Aqui, uma princesa se disfarça de menino órfão, um cavaleiro se prepara para encarar uma pérfida feiticeira e bárbaros descem das Montanhas da Lua para saquear os campos. Em um contexto de incesto e fratricídio, alquimia e assassinato, a vitória será dos homens e mulheres que possuírem o mais frio aço... e o mais frio coração. Pois, quando se desperta a fúria dos reis, a terra inteira treme. “Martin corresponde a todas as expectativas criadas por A guerra dos tronos e dá continuidade ao que está destinada a ser a melhor série de fantasia já escrita.” — The Denver Post'),
            ('A Tormenta de Espadas', 'George R. R. Martin', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12116911/1008972505.jpg?v=637142277126170000', 'Este é o terceiro volume da série As Crônicas de Gelo e Fogo, que inclui A guerra dos tronos e A fúria dos reis. Já considerada um clássico, a obra emocionante de George R. R. Martin é um dos maiores feitos da literatura fantástica de todos os tempos. O futuro de Westeros está em jogo, e ninguém descansará até que os Sete Reinos tenham explodido em uma verdadeira tormenta de espadas. Dos cinco pretendentes ao trono, um está morto e outro caiu em desgraça, e ainda assim a guerra continua em toda sua fúria, enquanto alianças são feitas e desfeitas. Joffrey, da Casa Lannister, ocupa o Trono de Ferro, como o instável governante dos Sete Reinos, ao passo que seu rival mais amargo, lorde Stannis, jaz derrotado e enfeitiçado pelas promessas da Mulher Vermelha. O jovem Robb, da Casa Stark, ainda comanda o Norte, contudo, e planeja sua batalha contra os Lannister, mesmo que sua irmã seja refém deles em Porto Real. Enquanto isso, Daenerys Targaryen atravessa um continente deixando um rastro de sangue a caminho de Westeros, levando consigo os três únicos dragões existentes em todo o mundo. Enquanto forças opostas avançam para uma gigantesca batalha final, um exército de selvagens chega dos confins da civilização. Em seu rastro vem uma horda de terríveis criaturas místicas – os Outros: um batalhão de mortos-vivos cujos corpos são imparáveis. “Eu sempre espero o melhor de George R. R. Martin, e ele sempre entrega.” — Robert Jordan, autor de A roda do tempo'),
            ('O Festim dos Corvos', 'George R. R. Martin', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12106266/1002912384.jpg?v=637142237379070000', 'O festim dos corvos é o quarto livro da monumental saga de fantasia As Crônicas de Gelo e Fogo, sucesso internacional que deu origem a Game of Thrones. Neste livro, Martin coloca um reino dilacerado à beira da paz... só para ser lançado de novo rumo ao terror e à destruição. Há séculos os sete grandes reinos de Westeros se enfrentam em amargas disputas, batalhas e traições. Agora, com Joffrey Baratheon e Robb Stark fora da jogada e lordes insignificantes competindo pelas Ilhas de Ferro, a guerra que devorou o continente parece ter finalmente chegado ao fim. No entanto, como após todo grande conflito, não demora para que os sobreviventes, os bandidos, os renegados e os carniceiros avancem para disputar o espólio dos mortos. Por toda Westeros os lordes se agitam, formando alianças e fazendo planos, enquanto nomes conhecidos e desconhecidos se apresentam para tomar parte das danças políticas. Todos precisam lançar mão de suas habilidades e poderes para encarar os tempos de terror que se aproximam. Nobres e plebeus, soldados e feiticeiros, assassinos e saqueadores devem arriscar suas fortunas... e suas vidas, pois em um festim de corvos, muitos são os convidados — e poucos os sobreviventes. “Quando a escrita é boa nesse nível, vale a pena esperar.” — Entertainment Weekly'),
            ('A Danca dos Dragoes', 'George R. R. Martin', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12106275/1002912388.jpg?v=637142237396400000', 'A Dança dos Dragões O futuro dos Sete Reinos ainda é incerto - novas ameaças e novos inimigos surgem a cada momento. Além do Mar Estreito, Daenerys Targaryen, a última herdeira da Casa Targaryen, governa uma cidade construída sobre o pó e a morte. Mas seus inimigos são cada vez mais numerosos e farão de tudo para destruí-la. Enquanto isso, dois jovens embarcam em missões distintas, mas que podem mudar o destino da Mãe dos Dragões. No Norte, Jon Snow - 998º Senhor Comandante da Patrulha da Noite - fará de tudo para garantir a segurança da Muralha. Para isso, não hesitará em transformar amigos em inimigos e vice-versa. Traições, revelações e um fantasma do passado que volta para assombrar quando menos se espera: em todos os cantos de Westeros e de Essos, mercadores, foras da lei, mestres, reis, nobres, escravos, soldados e troca-peles estão prestes a encarar fatos inesperados. Alguns fracassarão, outros se aproveitarão das forças sombrias que crescem cada vez mais. Mas, neste momento de inquietude crescente, as marés da política e do destino levarão inevitavelmente à maior dança de todas.'),
            ('O Senhor Dos Aneis: A Sociedade Do Anel', 'Tolkien, J.R.R.', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12116860/1009411423.jpg?v=637142276906270000', 'A Sociedade do Anel O volume inicial de O Senhor dos Anéis, lançado originalmente em julho de 1954, foi o primeiro grande épico de fantasia moderno, conquistando milhões de leitores e se tornando o padrão de referência para todas as outras obras do gênero até hoje. A imaginação prodigiosa de J.R.R. Tolkien e seu conhecimento profundo das antigas mitologias da Europa permitiram que ele criasse um universo tão complexo e convincente quanto o mundo real. A Sociedade do Anel começa no Condado, a região rural do oeste da Terra-média onde vivem os diminutos e pacatos hobbits. Bilbo Bolseiro, um dos raros aventureiros desse povo, cujas peripécias foram contadas em O Hobbit, resolve ir embora do Condado e deixa sua considerável herança nas mãos de seu jovem parente Frodo. O mais importante legado de Bilbo é o anel mágico que costumava usar para se tornar invisível. No entanto, o mago Gandalf, companheiro de aventuras do velho hobbit, revela a Frodo que o objeto é o Um Anel, a raiz do poder demoníaco de Sauron, o Senhor Sombrio, que deseja escravizar todos os povos da Terra-média. A única maneira de eliminar a ameaça de Sauron é destruir o Um Anel nas entranhas da própria montanha de fogo onde foi forjado. A revelação faz com que Frodo e seus companheiros hobbits Sam, Merry e Pippin deixem a segurança do Condado e iniciem uma perigosa jornada rumo ao leste.'),
            ('O Senhor Dos Aneis: As Duas Torres', 'Tolkien, J.R.R.', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12116861/1009410939.jpg?v=637142276911570000', 'As Duas Torres O segundo volume de O Senhor dos Anéis, mais importante épico de fantasia moderno, narra os caminhos separados seguidos pelos membros da Sociedade do Anel em sua luta para deter Sauron, o Senhor Sombrio da terra de Mordor, e destruir o Um Anel, no qual está contida a maior parte do poder do tirano demoníaco imaginado por J.R.R. Tolkien. Um ataque-surpresa pôs fim à jornada conjunta da Sociedade do Anel. De um lado, o trio formado pelo elfo Legolas, pelo anão Gimli e por Aragorn, herdeiro da realeza dos Homens, tenta resgatar os jovens hobbits Merry e Pippin, capturados por guerreiros-órquicos. A busca pelos companheiros perdidos levará os três a confrontar os cavaleiros do reino de Rohan e o mago renegado Saruman, que também deseja o Um Anel para si. Enquanto isso, do outro lado das montanhas, Frodo e Sam buscam uma maneira de entrar em Mordor e chegar até a montanha onde o Anel foi forjado, único lugar onde é possível destruí-lo. Para isso, acabam recebendo a ajuda de seu mais improvável aliado: Gollum, a criatura que chegou a ter o Anel sob seu poder durante centenas de anos e que ainda é devorada, em corpo e alma, pelo desejo de voltar a possuí-lo. Com cenas que mesclam o heroico e o intimista, o sublime e o cômico, As Duas Torres abriga algumas das criações mais inesquecíveis da imaginação de J.R.R. Tolkien'),
            ('O Senhor Dos Aneis: O Retorno Do Rei', 'Tolkien, J.R.R.', 'http://lojasaraiva.vteximg.com.br/arquivos/ids/12116862/1009410727.jpg?v=637142276914700000', 'O Retorno do Rei A guerra entre os Povos Livres da Terra-média e Sauron, o Senhor Sombrio da terra de Mordor, chega a seu clímax neste terceiro volume do romance O Senhor dos Anéis. As batalhas grandiosas que estão prestes a acontecer, no entanto, são apenas o pano de fundo para o verdadeiro drama: a missão quase suicida dos hobbits Frodo e Sam, que tentam destruir o Um Anel, fonte do poder de Sauron, infiltrando-se no coração do território do Inimigo. Em O Retorno do Rei, acompanhamos o mago Gandalf e o hobbit Pippin em sua visita à a majestosa cidade de Minas Tirith, que já foi o principal baluarte dos Homens contra a ameaça de Sauron, mas que está prestes a sucumbir diante da força avassaladora do Senhor Sombrio. Outros membros da Sociedade do Anel se juntam a Aragorn, herdeiro da longa linhagem dos reis de Minas Tirith, na tentativa de evitar que a antiga capital do reino de Gondor seja destruída. Nas fronteiras de Mordor, Sam resgata Frodo, e os dois hobbits partem para o último estágio de sua jornada rumo ao Monte da Perdição, uma jornada que testará os limites do corpo e da mente dos pequenos heróis. O livro inclui ainda numerosos apêndices, nos quais Tolkien explora detalhes da história, das línguas, dos alfabetos e até dos calendários de seu mundo ficcional.')
        ";
    }
}
