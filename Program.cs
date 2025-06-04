using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JueguitoDeRol
{
    class Program
    {
        static int vidaplayer = 100 /* vida actual del jugador*/, vidamáxima =100, maná = 100 /* maná actual del jugador*/, manábase/* vida actual del jugador*/, defensa = 10, ataquealiado = 0 /* daño del jugador*/, ataquealiadocrit /* ataque aliado con crítico*/, buffmomentaneo /*daño extra para hechizos*/, lvl = 1, Eleccionenemigo/*seleccionar que enemigo aparece*/, foto /*elegir la imagen que sale*/, ataque /*probabilidad de ataque*/, ataquecrit /*Probabilidad de ataque critico*/, ataqueenemigo/* vida actual del jugador*/, pocion = 50, pocionmana, contador/*Cuenta los tiks de daño del hechizo de fuego*/;
        static int golpeenemigo/*daño del enemigo*/, vidaenemigo,vidaenemigomaxima, dañorecibido/*daño que afecta a la vida del jugador*/,quemadura /*probablidad de quemar */, statquemadura /*determina cuanto quita (10% de a vida del enemigo)*/, maxpocionesV/*Pociones de vida que ha elegido el jugador*/, maxpocionesM/*Pociones de maná que ha elegido el jugador*/;
        static string nombre, clase, raza, armas, elecciongolpe/*elige la opción del jugador*/, eleccióncamino;
        static bool personajeterminado = true/*para el bucle del creador de personaje*/, claseterminada = true/*para el bucle del elegir clase*/, razaterminada = true/*para el bucle del elegir clase*/, confirmararmaG = true/*para el bucle del elegir armamento*/, enemigoMuerto/*para el bucle de la pelea*/, muerto = false/*por si el jugador muere*/, hielo = false/*comprueba si el turno siguiente el enemigo falla o no*/, quemadito = false/*comprueba si el turno siguiente el enemigo se está quemando o no*/;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Opening();
            Console.Clear();
            Console.WriteLine("Bienvenido, estás a punto de formar parte de una partida corta de ROL, lo primero\ntienes que elegir que clase de personaje quieres, que raza, nombre e historia tendrá.");
            CreaPersonaje();
            Historiacomienzo();
            Console.ReadKey();
            Combates();
            Console.ReadKey();
            Console.Clear();
            foto = 7;
            Fotitos();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Ganaste");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Read();
        }
        static void CreaPersonaje()
        {
            while (claseterminada == true)
            {
                Console.WriteLine("Elige la clase de tu personaje");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escribe el número 1.Guerrero 2.Mago 3.Explicación Guerrero 4.Explicación Mago");
                Console.ForegroundColor = ConsoleColor.Green;
                clase = Console.ReadLine();
                clase = clase.Trim();
                if (clase != "")
                {
                    switch (clase)
                    {
                        case "1":
                            clase = "Guerrero";
                            claseterminada = false;
                            Console.WriteLine("Has elegido Guerrero");
                            break;
                        case "2":
                            clase = "Mago";
                            claseterminada = false;
                            Console.WriteLine("Has elegido Mago");
                            break;
                        case "3":
                            Console.WriteLine("EL guerrero se distingue por ser un luchador cuerpo a cuerpo que no se le da bien la magia y lleva una protección fuerte, por tanto tiene más vida");
                            break;
                        case "4":
                            Console.WriteLine("El mago se distingue por tener un daño enorme frente a monstruos pero esté gasta maná con cada ataque asique no se puede abusar");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("clase introducida invalida");
                }
            }
            while (razaterminada == true)
            {
                Console.WriteLine("Elige la raza de tu personaje");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escribe si quieres ser un 1.Gnomo 2.Enano 3.Humano 4.Elfo");
                Console.ForegroundColor = ConsoleColor.Green;
                raza = Console.ReadLine();
                raza = raza.Trim();
                if (raza != "")
                {
                    switch (raza)
                    {
                        case "1":
                            raza = "Gnomo";
                            razaterminada = false;
                            Console.WriteLine("Has elegido Gnomo");
                            break;
                        case "2":
                            raza = "Enano";
                            razaterminada = false;
                            Console.WriteLine("Has elegido Enano");
                            break;
                        case "3":
                            raza = "Humano";
                            razaterminada = false;
                            Console.WriteLine("Has Elegido Humano");
                            break;
                        case "4":
                            raza = "Elfo";
                            razaterminada = false;
                            Console.WriteLine("Has elegido Elfo");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("clase introducida invalida");
                }
            }
            while (personajeterminado == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Elige el nombre de tu personaje");
                Console.ForegroundColor = ConsoleColor.Green;
                nombre = Console.ReadLine();
                nombre = nombre.Trim();
                if (nombre != "")
                {
                    personajeterminado = false;
                    Console.WriteLine("Personaje Creado");
                }
                else
                {
                    Console.WriteLine("clase introducida invalida");
                }
            }
        }
        static void Historiacomienzo()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido {0}, reconocido {1} {2}", nombre, raza, clase);
            Console.WriteLine("Antes de entrar a la cueva, dónde buscas un fantástico tesoro, deberás elegir tu armamento");
            Armas();
            Console.WriteLine("Tus estadisticas son las siguientes :\n-Nivel: {0}\n-Puntos de vida: {1}\n-Puntos de defensa: {2}\n-Puntos de maná: {3}\n-Puntos de ataque: {4}", lvl, vidaplayer, defensa, maná, ataquealiado);
        }
        static void Armas()
        {
            if (clase == "Guerrero")
            {
                while (confirmararmaG)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1. Deseas portar un espadón tan grande como una persona (23 DA daño de ataque // +6 DF defensa física)\n2. Portar una espada y un escudo (13 DA daño de ataque // +14 DF defensa física)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    armas = Console.ReadLine();
                    armas = armas.Trim();
                    if (armas != "" && armas == "1")
                    {
                        confirmararmaG = false;
                        defensa = defensa + 6;
                        ataquealiado = ataquealiado + 23;
                        manábase = 100;
                        armas = "Espadon";
                        maxpocionesV = 7;
                        Console.WriteLine("Portas un espadón tan grande como una persona (23 DA daño de ataque // +6 DF defensa física) y 7 pociones curativas");
                    }
                    else if (armas != "" && armas == "2")
                    {
                        confirmararmaG = false;
                        armas = "espada/escudo";
                        defensa = defensa + 14;
                        ataquealiado = ataquealiado + 13;
                        manábase = 100;
                        maxpocionesV = 7;
                        Console.WriteLine("Portas una espada y un escudo (13 DA daño de ataque // +14 DF defensa física) y 7 pociones curativas");
                    }
                    else
                    {
                        Console.WriteLine("Valor introducido incorrecto");
                    }
                }

            }
            else
            {
                while (confirmararmaG)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1. Deseas portar un libro de hechizos y un atuendo de mago rúnicos (20 DA daño de ataque // +4 DF defensa física // +60 de maná)\n2. Portar una bastón mágico ancestral y atuendo de aprendiz rúnico(30 DA daño de ataque // +2 DF defensa física // +20 de maná)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    armas = Console.ReadLine();
                    armas = armas.Trim();
                    if (armas != "" && armas == "1")
                    {
                        confirmararmaG = false;
                        armas = "libro";
                        defensa = defensa + 4;
                        ataquealiado = ataquealiado + 20;
                        maná = maná + 60;
                        manábase = 160;
                        maxpocionesM = 3;
                        maxpocionesV = 4;
                        Console.WriteLine("Portas un libro de hechizos y un atuendo de mago rúnico\n(20 DA daño de ataque // +4 DF defensa física // +60 de maná) y 4 pociones curativas y 3 pociones de maná");
                    }
                    else if (armas != "" && armas == "2")
                    {
                        confirmararmaG = false;
                        armas = "bastón";
                        defensa = defensa + 2;
                        ataquealiado = ataquealiado + 30;
                        maná = maná + 20;
                        manábase = 120;
                        maxpocionesM = 3;
                        maxpocionesV = 4;
                        Console.WriteLine("Portas una bastón mágico ancestral y atuendo de aprendiz rúnico\n(30 DA daño de ataque // +2 DF defensa física // +20 de maná) y 4 pociones curativas y 3 pociones de maná");
                    }
                    else
                    {
                        Console.WriteLine("Valor introducido incorrecto");
                    }
                }
            }
        }
        static void Combates()
        {
        start:
            muerto = false;
            enemigoMuerto = true;
            Eleccionenemigo = 1;
            Console.Clear();
            Console.WriteLine("Al entrar encuentras un enemigo de frente, es un zombie");
            foto = 2;
            Fotitos();
            StatsEnemigos();
            foto = 5;
            Pelea();
            if (muerto)
            {
                if (clase == "Guerrero")
                {
                    maxpocionesV = 7;
                    maxpocionesM = 0;
                }
                else
                {
                    maxpocionesV = 4;
                    maxpocionesM = 3;
                }
                vidaplayer = vidamáxima;
                maná = manábase;
                Console.Clear();
                Console.WriteLine("Has Muerto");
                Console.WriteLine("Reintentar...");
                Console.ReadKey();
                goto start;
            }
            Eleccionenemigo = 2;
            enemigoMuerto = true;
            DecidirCamino();
            Console.Clear();
            Console.WriteLine("Al entrar encuentras un enemigo de frente, es una Araña");
            foto = 3;
            Fotitos();
            StatsEnemigos();
            foto = 6;
            Pelea();
            if (muerto)
            {
                if (clase == "Guerrero")
                {
                    maxpocionesV = 7;
                    maxpocionesM = 0;
                }
                else
                {
                    maxpocionesV = 4;
                    maxpocionesM = 3;
                }
                lvl = 2;
                vidaplayer = vidamáxima;
                maná = manábase;
                Console.Clear();
                Console.WriteLine("Has Muerto");
                Console.WriteLine("Reintentar...");
                Console.ReadKey();
                goto start;
            }
            Eleccionenemigo = 3;
            enemigoMuerto = true;
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Al entrar encuentras Al Dragon Voorux");
            foto = 1;
            Fotitos();
            StatsEnemigos();
            foto = 4;
            Pelea();
            if (muerto)
            {
                if (clase == "Guerrero")
                {
                    maxpocionesV = 7;
                    maxpocionesM = 0;
                }
                else
                {
                    maxpocionesV = 4;
                    maxpocionesM = 3;
                }
                lvl = 3;
                vidaplayer = vidamáxima;
                maná = manábase;
                Console.Clear();
                Console.WriteLine("Has Muerto");
                Console.WriteLine("Reintentar...");
                Console.ReadKey();
                goto start;
            }
        }
        static void Pelea()
        {
            while (enemigoMuerto)
            {
                if (quemadito)
                {
                    if (contador <=2)
                    {
                        if (vidaenemigo >= 1)
                        {
                            if (clase == "Guerrero")
                            {
                                Guerrero();
                            }
                            else
                            {
                                Mago();
                            }
                            if (vidaplayer > vidamáxima)
                            {
                                vidaplayer = vidamáxima;
                            }
                            if (maná > manábase)
                            {
                                maná = manábase;
                            }
                            Enemigos();
                            statquemadura = vidaenemigomaxima /10;
                            Console.WriteLine("El enemigo está en llamas -{0} de vida este turno", statquemadura);
                            vidaenemigo = vidaenemigo - statquemadura;
                            hielo = false;
                            contador++;
                            Console.WriteLine(contador);
                            Console.WriteLine("Tu Vida :{0}", vidaplayer);
                            Console.WriteLine("Tu Maná :{0}", maná);
                        }
                        else
                        {
                            quemadito = false;
                            contador = 0;
                            enemigoMuerto = false;
                            Combategando();
                        }
                        if (vidaplayer <= 0)
                        {
                            quemadito = false;
                            contador = 0;
                            enemigoMuerto = false;
                            muerto = true;
                        }
                    }
                    else
                    {
                        quemadito = false;
                        contador = 0;
                    }
                }
                else
                {
                    if (vidaenemigo >= 1)
                    {
                        if (clase == "Guerrero")
                        {
                            Guerrero();
                        }
                        else
                        {
                            Mago();
                        }
                        if (vidaplayer > vidamáxima)
                        {
                            vidaplayer = vidamáxima;
                        }
                        if (maná > manábase)
                        {
                            maná = manábase;
                        }
                        Enemigos();
                        hielo = false;
                        Console.WriteLine("Tu Vida :{0}", vidaplayer);
                        Console.WriteLine("Tu Maná :{0}", maná);
                    }
                    else
                    {
                        quemadito = false;
                        contador = 0;
                        enemigoMuerto = false;
                        Combategando();
                    }
                    if (vidaplayer <= 0)
                    {
                        quemadito = false;
                        contador = 0;
                        enemigoMuerto = false;
                        muerto = true;
                    }
                }
                
            }

        }
        static void Enemigos()
        {
            Random probabilidadataqueenemigo = new Random();
            switch (Eleccionenemigo)
            {
                case 1: //Zombie
                    if (hielo)
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo == -1)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("El zombie te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    else
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo >= 30)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("El zombie te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    
                    break;
                case 2: //Araña
                    if (hielo)
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo == -1)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("La araña te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    else
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo >= 20)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("La araña te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    break;
                case 3: //Dragon
                    if (hielo)
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo == -1)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("Voorux te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    else
                    {
                        ataqueenemigo = probabilidadataqueenemigo.Next(0, 100);
                        if (ataqueenemigo >= 10)
                        {
                            dañorecibido = golpeenemigo - defensa;
                            vidaplayer = vidaplayer - dañorecibido;
                            Console.WriteLine("Voorux te ha atacado, te ha infligido {0} de daño", dañorecibido);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque enemigo ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    break;
            }
        }
        static void StatsEnemigos()
        {
            switch (Eleccionenemigo)
            {
                case 1: //Zombie
                    vidaenemigomaxima = 150;
                    vidaenemigo = 150;
                    golpeenemigo = 40;
                    break;
                case 2: //Araña
                    vidaenemigomaxima = 250;
                    vidaenemigo = 250;
                    golpeenemigo = 60;
                    break;
                case 3: //Jefe
                    vidaenemigomaxima = 500;
                    vidaenemigo = 500;
                    golpeenemigo = 100;
                    break;
            }
        }
        static void Nivel()
        {
            switch (lvl)
            {
                case 1:
                    vidaplayer = 100;
                    vidamáxima = 100;
                    maná = 100;
                    defensa = 0;
                    ataquealiado = 0;
                    break;
                case 2:
                    vidaplayer = 120;
                    vidamáxima = 120;
                    maná = manábase + 20;
                    defensa = defensa + 5;
                    ataquealiado = ataquealiado + 6;
                    break;
                case 3:
                    vidaplayer = 150;
                    vidamáxima = 150;
                    maná = manábase + 30;
                    defensa = defensa + 10;
                    ataquealiado = ataquealiado + 10;
                    break;
                case 4:
                    vidaplayer = 200;
                    vidamáxima = 200;
                    maná = manábase + 50;
                    defensa = defensa + 20;
                    ataquealiado = ataquealiado + 20;
                    break;
            }
        }
        static void Combategando()
        {
            Console.Clear();
            Fotitos();
            ++lvl;
            Console.WriteLine("Lo has matado, has subido a nivel {0}", lvl);
            Console.ReadLine();
            Console.Clear();
            Nivel();
            Console.WriteLine("Tus estadisticas son las siguientes :\n-Nivel: {0}\n-Puntos de vida: {1}\n-Puntos de defensa: {2}\n-Puntos de maná: {3}\n-Puntos de ataque: {4}", lvl, vidaplayer, defensa, maná, ataquealiado);
        }
        static void DecidirCamino()
        {
            Console.WriteLine("Al derrotar al zombie tienes que decidir si ir 1.Izquierda o 2.Derecha.");
            eleccióncamino = Console.ReadLine();
        }
        static void Fotitos() 
        {
            switch (foto)
                {
                case 1:
                    Console.WriteLine(@"                                                          ___
                                                       .~))>>
                                                      .~)>>
                                                    .~))))>>>
                                                  .~))>>             ___
                                                .~))>>)))>>      .-~))>>  
                                              .~)))))>>       .-~))>>)>
                                            .~)))>>))))>>  .-~)>>)>
                        )                 .~))>>))))>>  .-~)))))>>)>
                     ( )@@*)             //)>))))))  .-~))))>>)>
                   ).@(@@               //))>>))) .-~))>>)))))>>)>
                 (( @.@).              //))))) .-~)>>)))))>>)>
               ))  )@@*.@@ )          //)>))) //))))))>>))))>>)>
            ((  ((@@@.@@             |/))))) //)))))>>)))>>)>
           )) @@*. )@@ )   (\_(\-\b  |))>)) //)))>>)))))))>>)>
         (( @@@(.@(@ .    _/`-`  ~|b |>))) //)>>)))))))>>)>
          )* @@@ )@*     (@) (@)  /\b|))) //))))))>>))))>>
        (( @. )@( @ .   _/       /  \b)) //))>>)))))>>>_._
         )@@ (@@*)@@.  (6,   6) / ^  \b)//))))))>>)))>>   ~~-.
      ( @jgs@@. @@@.*@_ ~^~^~, /\  ^  \b/)>>))))>>      _.     `,
       ((@@ @@@*.(@@ .   \^^^/' (  ^   \b)))>>        .'         `,
        ((@@).*@@ )@ )    `-'   ((   ^  ~)_          /             `,
          (@@. (@@ ).           (((   ^    `\        |               `.
            (*.@*              / ((((        \        \      .         `.
                              /   (((((  \    \    _.-~\     Y,         ;
                             /   / (((((( \    \.-~   _.`  _.- ~`,       ;
                            /   /   `(((((())(((((~      `,     ;
            _ / _ /      ` /   /'                  ;     ;
                      _.- ~_.- ~           /  / '                _.-~   _.'
                    ((((~~              / / '              _.-~ __.--~
                                       ((((__.- ~_.- ~
                                                   .'   .~~
                                                   :    , '
                                                   ~~~~~");
                    break;
                case 2: //zombie
                    Console.WriteLine(@"                                .....            
                               C C  /            
                              /<   /             
               ___ __________/_#__=o             
              /(- /(\_\________   \              
              \ ) \ )_      \o     \             
              /|\ /|\       |'     |             
                            |     _|             
                            /o   __\             
                           / '     |             
                          / /      |             
                         /_/\______|             
                        (   _(    <              
                         \    \    \             
                          \    \    |            
                           \____\____\           
                           ____\_\__\_\          
                         /`   /`     o\          
                         |___ |_______|");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
             />\\//\\/>\             |       /<\//\\//<\
              \Y  \>
            />  //\ />\ \>    .;`'`/`;<\   ;/> /> \>/ \\: \>
           />  //: />  \> \>    o o    /> /> />\>  \\  \>
          />  //  /> \> \> \>  oO Oo />        \\  \>
         />  //  />   `;.;. . (  ..  )  .;`;`     \>  \\  \>
       />  //: />           \\  \>
      /> // />             \>                          <\ \\ <\
      \\ \>
     />// />                  /`//\                      <\ \\<\
    \\ \>
    />///>                   _//\ \/                       <\\\<\
   \\\>
   />//>                                                     <\\<\
  \\>
    \\(                                                       )//
      \\                                                     //");
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 4:
                    Console.WriteLine(@"                                                          ___
                                                       .~))>>
                                                      .~)>>
                                                    .~))))>>>
                                                  .~))>>             ___
                                                .~))>>)))>>      .-~))>>  
                                              .~)))))>>       .-~))>>)>
                                            .~)))>>))))>>  .-~)>>)>
                        )                 .~))>>))))>>  .-~)))))>>)>
                     ( )@@*)             //)>))))))  .-~))))>>)>
                   ).@(@@               //))>>))) .-~))>>)))))>>)>
                 (( @.@).              //))))) .-~)>>)))))>>)>
               ))  )@@*.@@ )          //)>))) //))))))>>))))>>)>
            ((  ((@@@.@@             |/))))) //)))))>>)))>>)>
           )) @@*. )@@ )   (\_(\-\b  |))>)) //)))>>)))))))>>)>
         (( @@@(.@(@ .    _/`-`  ~|b |>))) //)>>)))))))>>)>
          )* @@@ )@*     (X) (X)  /\b|))) //))))))>>))))>>
        (( @. )@( @ .   _/       /  \b)) //))>>)))))>>>_._
         )@@ (@@*)@@.  (6,   6) / ^  \b)//))))))>>)))>>   ~~-.
      ( @jgs@@. @@@.*@_ ~^~^~, /\  ^  \b/)>>))))>>      _.     `,
       ((@@ @@@*.(@@ .   \^^^/' (  ^   \b)))>>        .'         `,
        ((@@).*@@ )@ )    `-'   ((   ^  ~)_          /             `,
          (@@. (@@ ).           (((   ^    `\        |               `.
            (*.@*              / ((((        \        \      .         `.
                              /   (((((  \    \    _.-~\     Y,         ;
                             /   / (((((( \    \.-~   _.`  _.- ~`,       ;
                            /   /   `(((((())(((((~      `,     ;
            _ / _ /      ` /   /'                  ;     ;
                      _.- ~_.- ~           /  / '                _.-~   _.'
                    ((((~~              / / '              _.-~ __.--~
                                       ((((__.- ~_.- ~
                                                   .'   .~~
                                                   :    , '
                                                   ~~~~~");
                    break;
                case 5: //zombie Muerto
                    Console.WriteLine(@"                                .....            
                               X X  /            
                              /<   /             
               ___ __________/_#__=o             
              /(- /(\_\________   \              
              \ ) \ )_      \o     \             
              /|\ /|\       |'     |             
                            |     _|             
                            /o   __\             
                           / '     |             
                          / /      |             
                         /_/\______|             
                        (   _(    <              
                         \    \    \             
                          \    \    |            
                           \____\____\           
                           ____\_\__\_\          
                         /`   /`     o\          
                         |___ |_______|");
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
                                     |
             />\\//\\/>\             |       /<\//\\//<\
              \Y  \>
            />  //\ />\ \>    .;`'`/`;<\   ;/> /> \>/ \\: \>
           />  //: />  \> \>    xX Xx    /> /> />\>  \\  \>
          />  //  /> \> \> \>  xX Xx />        \\  \>
         />  //  />   `;.;. . (  ..  )  .;`;`     \>  \\  \>
       />  //: />           \\  \>
      /> // />             \>                          <\ \\ <\
      \\ \>
     />// />                  /`//\                      <\ \\<\
    \\ \>
    />///>                   _//\ \/                       <\\\<\
   \\\>
   />//>                                                     <\\<\
  \\>
    \\(                                                       )//
      \\                                                     //");
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(@"                            _.--.
                        _.-'_:-'||
                    _.-'_.-::::'||
               _.-:'_.-::::::'  ||
             .'`-.-:::::::'     ||
            /.'`;|:::::::'      ||_
           ||   ||::::::'     _.;._'-._
           ||   ||:::::'  _.-!oo @.!-._'-.
           \'.  ||:::::.-!()oo @!()@.-'_.|
            '.'-;|:.-'.&$@.& ()$%-'o.'\U||
              `>'-.!@%()@'@_%-'_.-o _.|'||
               ||-._'-.@.-'_.-' _.-o  |'||
               ||=[ '-._.-\U/.-'    o |'||
               || '-.]=|| |'|      o  |'||
               ||      || |'|        _| ';
               ||      || |'|    _.-'_.-'
               |'-._   || |'|_.-'_.-'
                '-._'-.|| |' `_.-'
                    '-.||_/.-'");
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }
        static void Opening()
        {
            Console.WriteLine(@"
-----------------------------------------------------------------------
-----------------------------------------------------------------------
                                 _                 _                  
                                | |               | |                 
  ___ __ ___   _____    __ _  __| |_   _____ _ __ | |_ _   _ _ __ ___                
 / __/ _` \ \ / / _ \  / _` |/ _` \ \ / / _ \ '_ \| __| | | | '__/ _ \       
| (_| (_| |\ V /  __/ | (_| | (_| |\ V /  __/ | | | |_| |_| | | |  __/
 \___\__,_| \_/ \___|  \__,_|\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|


-----------------------------------------------------------------------
-----------------------------------------------------------------------");
            Console.ReadKey();
        }
        static void Mago()
        {
            ataquealiadocrit = ataquealiado * 2;
            Random probabilidadataque = new Random();
            Random probabilidcrit = new Random();
            Console.ForegroundColor = ConsoleColor.Red;
            if (maxpocionesM <= 0 && maxpocionesV <= 0)
            {
                Console.WriteLine("Elige 1.Para ataque 2.No te quedan pociones curativas\n3.Bola de Fuego (Probabilidad de dejar al enemigo en llamas durante 3 turnos - 60 de maná)\n4.Hechizo helado (El enemigo no ataca durante el siguiente turno - 60 de maná) 5.No te quedan pociones de maná)");
            }
            else if (maxpocionesV <=0)
            {
                Console.WriteLine("Elige 1.Para ataque 2.No te quedan pociones de curativas\n3.Bola de Fuego (Probabilidad de dejar al enemigo en llamas durante 3 turnos - 60 de maná)\n4.Hechizo helado (El enemigo no ataca durante el siguiente turno - 60 de maná) 5.Para tomarte una poción de maná (te quedan {0} pociones de maná)", maxpocionesM);
            }
            else if (maná <= 59)
            {
                Console.WriteLine("Elige 1.Para ataque 2.Para tomarte una poción curativa (te quedan {0} pociones curativas)\n3.No te queda maná para más hechizos\n4.No te queda maná para más hechizos 5.Para tomarte una poción de maná (te quedan {1} pociones de maná)", maxpocionesV, maxpocionesM);
            }
            else if (maxpocionesM <= 0)
            {
                Console.WriteLine("Elige 1.Para ataque 2.Para tomarte una poción curativa (te quedan {0} pociones curativas)\n3.Bola de Fuego (Probabilidad de dejar al enemigo en llamas durante 3 turnos - 60 de maná)\n4.Hechizo helado (El enemigo no ataca durante el siguiente turno - 60 de maná) 5.No te quedan pociones de maná", maxpocionesV);
            }
            else if (maxpocionesV <= 0 && maná <=59)
            {
                Console.WriteLine("Elige 1.Para ataque 2.No te quedan pociones curativas\n3.No te queda maná para más hechizos\n4.No te queda maná para más hechizos 5.Para tomarte una poción de maná (te quedan {0} pociones de maná)", maxpocionesM);
            }
            else if (maxpocionesM <= 0 && maxpocionesV <= 0 && maxpocionesM <= 0)
            {
                Console.WriteLine("Elige 1.Para ataque 2.No te quedan pociones curativas\n3.No te queda maná para más hechizos\n4.No te queda maná para más hechizos 5.No te quedan pociones de maná");
            }
            else
            {
                Console.WriteLine("Elige 1.Para ataque 2.Para tomarte una poción curativa (te quedan {0} pociones curativas)\n3.Bola de Fuego (Probabilidad de dejar al enemigo en llamas durante 3 turnos - 60 de maná)\n4.Hechizo helado (El enemigo no ataca durante el siguiente turno - 60 de maná) 5.Para tomarte una poción de maná (te quedan {1} pociones de maná)",maxpocionesV, maxpocionesM);
            }
            Console.ForegroundColor = ConsoleColor.Green;
                elecciongolpe = Console.ReadLine();
                switch (elecciongolpe)
                {
                    case "1":
                        ataque = probabilidadataque.Next(0, 100);
                        ataquecrit = probabilidcrit.Next(0, 100);
                        if (ataque >= 10)
                        {
                            if (ataquecrit >= 80)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiadocrit;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiado;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                    case "":
                        ataque = probabilidadataque.Next(0, 100);
                        ataquecrit = probabilidcrit.Next(0, 100);
                        if (ataque >= 20)
                        {
                            if (ataquecrit >= 80)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiadocrit;
                            }
                            else
                            {
                                Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                                vidaenemigo = vidaenemigo - ataquealiado;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                    case "2":
                    if (maxpocionesV >= 1)
                    {
                        pocion = 50 * lvl;
                        vidaplayer = vidaplayer + pocion;
                        maxpocionesV--;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Te has curado de +{0} puntos de vida", pocion);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("No te quedan pociones curativas");
                    }
                        break;
                    case "3":
                    if (maná >= 60)
                    {
                        quemadura = probabilidadataque.Next(0, 100);
                        if (quemadura >= 50)
                        {
                            buffmomentaneo = ataquealiado;
                            buffmomentaneo = buffmomentaneo + 30 * lvl;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Le has lanzado una bola de fuego, le has hecho +{0} puntos de daño", buffmomentaneo);
                            Console.ForegroundColor = ConsoleColor.Green;
                            vidaenemigo = vidaenemigo - buffmomentaneo;
                            quemadito = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El enemigo está en llamas");
                            Console.ForegroundColor = ConsoleColor.Green;
                            maná = maná - 60;
                        }
                        else
                        {
                            buffmomentaneo = ataquealiado;
                            buffmomentaneo = buffmomentaneo + 30 * lvl;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Le has lanzado una bola de fuego, le has hecho +{0} puntos de daño", buffmomentaneo);
                            Console.ForegroundColor = ConsoleColor.Green;
                            vidaenemigo = vidaenemigo - buffmomentaneo;
                            maná = maná - 60;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No te queda maná");
                    }
                        break;
                    case "4":
                    if (maná >= 60)
                    {
                        buffmomentaneo = ataquealiado;
                        buffmomentaneo = buffmomentaneo + 30 * lvl;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Le has lanzado un hechizo helado, le has hecho +{0} puntos de daño", buffmomentaneo);
                        Console.ForegroundColor = ConsoleColor.Green;
                        hielo = true;
                        vidaenemigo = vidaenemigo - buffmomentaneo;
                        maná = maná - 60;
                    }
                    else
                    {
                        Console.WriteLine("No te queda maná");
                    }
                        break;
                    case "5":
                        if (maxpocionesM >= 1)
                        {
                        pocionmana = 50 * lvl;
                        maná = maná + pocionmana;
                        maxpocionesM--;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Has recuperado {0} puntos de maná", pocion);
                        Console.ForegroundColor = ConsoleColor.Green;
                        }
                    else
                    {
                        Console.WriteLine("No te quedan pociones de maná");
                    }
                    break;

                default:
                    ataque = probabilidadataque.Next(0, 100);
                    ataquecrit = probabilidcrit.Next(0, 100);
                    if (ataque >= 20)
                    {
                        if (ataquecrit >= 80)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                            Console.ForegroundColor = ConsoleColor.Green;
                            vidaenemigo = vidaenemigo - ataquealiadocrit;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                            Console.ForegroundColor = ConsoleColor.Green;
                            vidaenemigo = vidaenemigo - ataquealiado;
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("El ataque ha fallado");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    break;
            }
        }
        static void Guerrero()
        {
            ataquealiadocrit = ataquealiado * 2;
            Random probabilidadataque = new Random();
            Random probabilidcrit = new Random();
                Console.ForegroundColor = ConsoleColor.Red;
            if (maxpocionesV >=1)
            {
                Console.WriteLine("Elige 1.Para ataque 2.Para tomarte una pocion (te quedan {0}, pociones curativas)", maxpocionesV);
                Console.ForegroundColor = ConsoleColor.Green;
                elecciongolpe = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Elige 1.Para ataque 2.No te quedan pociones");
                Console.ForegroundColor = ConsoleColor.Green;
                elecciongolpe = Console.ReadLine();
            }
                switch (elecciongolpe)
                {
                    case "1":
                        ataque = probabilidadataque.Next(0, 100);
                        ataquecrit = probabilidcrit.Next(0, 100);
                        if (ataque >= 10)
                        {
                            if (ataquecrit >= 75)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiadocrit;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiado;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                    case "":
                        ataque = probabilidadataque.Next(0, 100);
                        ataquecrit = probabilidcrit.Next(0, 100);
                        if (ataque >= 20)
                        {
                            if (ataquecrit >= 80)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiadocrit;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiado;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                    case "2":
                    if (maxpocionesV >= 1)
                    {
                        pocion = 50 * lvl;
                        vidaplayer = vidaplayer + pocion;
                        maxpocionesV--;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Te has curado de +{0} puntos de vida", pocion);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.WriteLine("No te quedan pociones de vida");
                    }
                        break;
                    default:
                        ataque = probabilidadataque.Next(0, 100);
                        ataquecrit = probabilidcrit.Next(0, 100);
                        if (ataque >= 20)
                        {
                            if (ataquecrit >= 80)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Le has hecho un ataque crítico +{0} de daño", ataquealiadocrit);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiadocrit;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Le has hecho +{0} de daño", ataquealiado);
                                Console.ForegroundColor = ConsoleColor.Green;
                                vidaenemigo = vidaenemigo - ataquealiado;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("El ataque ha fallado");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                }
        }
    }
}