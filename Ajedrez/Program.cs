using System;
using System.Text.RegularExpressions;

public class prueba
{
    // Declaración de variables globales
    static string pieza = "";
    static string PeonN = " \u265F  ";
    static string PeonB = " \u2659  ";
    static string TorreN = " \u265C  ";
    static string TorreB = " \u2656  ";
    static string CaballoN = " \u265E  ";
    static string CaballoB = " \u2658  ";
    static string AlfilN = " \u265D  ";
    static string AlfilB = " \u2657  ";
    static string DamaN = " \u265B  ";
    static string DamaB = " \u2655  ";
    static string ReyN = " \u265A  ";
    static string ReyB = " \u2654  ";
    static string BGB = "\u001B[47m" + "\u001B[30m";
    static string BGN = "\u001B[46m" + "\u001B[30m";
    static string BG = "\u001B[0m";
    static string[,] tablero = CrearTablero();
    private static string defaultcolor = "\u001B[37m";

    // Método principal
    static void Main(string[] args)
    {
        LimpiarConsola();
        ImprimirTablero(tablero);
        Menu();
    }


    // Métodos de comprobación
    // Método para validar que el usuario ingresó numeros enteros
    public static bool ValidarNumeros(string numero)
    {
        int num;
        bool isNumeric = int.TryParse(numero, out num);
        if (!isNumeric || num < 1 || num > 8)
        {
            return false;
        }
        return true;
    }

    // Método para validar que el usuario ingresó una pieza válida
    public static bool ValidarPiezaSeleccionada(string pieza)
    {
        string piezasPermitidasBlancas = "PATDCR";
        string piezasPermitidasNegras = "patdcr";
        if (piezasPermitidasBlancas.Contains(pieza.ToUpper()))
        {
            return true;
        }
        else if (piezasPermitidasNegras.Contains(pieza.ToLower()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void LimpiarConsola()
    {
        Console.Clear();
    }

    // Método para el menú
    private static void Menu()
    {
        bool finale = false, turnoBlancas;
        int opcion;
        do
        {
            bool TBlancas = true, TNegras = false;
            do
            {
                Console.WriteLine(BG + "Seleccione una opción: ");
                Console.WriteLine("Turno de blancas");
                turnoBlancas = true; // Comienza el juego en el turno de las blancas
                Console.WriteLine("1. Mover una pieza");
                Console.WriteLine("2. Salir");
                Console.WriteLine("Opción: ");
                string option = Console.ReadLine();
                while (!ValidarNumeros(option))
                {
                    Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
                    option = Console.ReadLine();
                }
                opcion = int.Parse(option);
                while (opcion <= 0 || opcion > 2)
                {
                    Console.WriteLine("Elige una opción válida: ");
                    option = Console.ReadLine();
                    while (!ValidarNumeros(option))
                    {
                        Console.Write(
                                "El valor ingresado no es un entero\n\nIntente nuevamente: ");
                        option = Console.ReadLine();
                    }
                    opcion = int.Parse(option);
                }
                // opcion = Console.ReadLineInt();
                switch (opcion)
                {
                    case 1:
                        ImprimirTablero(tablero);
                        bool TBlancaS = ElegirPieza(tablero, turnoBlancas);
                        if (TBlancaS)
                        {
                            TBlancas = false;
                        }
                        break;
                    default:
                        LimpiarConsola();

                        Console.WriteLine("Seguro que desea cerrar el programa? (1. Si/2. No)");
                        option = Console.ReadLine();
                        while (!ValidarNumeros(option))
                        {
                            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
                            option = Console.ReadLine();
                        }
                        opcion = int.Parse(option);
                        while (opcion <= 0 || opcion > 2)
                        {
                            Console.WriteLine("Elige una opción válida: ");
                            option = Console.ReadLine();
                            while (!ValidarNumeros(option))
                            {
                                Console.Write(
                                        "El valor ingresado no es un entero\n\nIntente nuevamente: ");
                                option = Console.ReadLine();
                            }
                            opcion = int.Parse(option);
                        }
                        if (opcion == 1)
                        {
                            LimpiarConsola();
                            Console.WriteLine("\t\t\t\u001B[33mGracias por jugar\n" + defaultcolor);
                            Console.WriteLine("Presiona enter para continuar...");
                            Console.ReadLine();
                            LimpiarConsola();
                            Console.WriteLine(
                                    "\t\t\t\t\u001B[33mCréditos\n\n" + defaultcolor
                                            + "* Angel Alejandro Becerra Rojas\r\n* Christian Axel Moreno Flores\r\n* Andrés Aguilera Hernández");
                            Console.WriteLine("\n\n Presiona enter para continuar...");
                            Console.ReadLine();
                            LimpiarConsola();
                            Environment.Exit(0);
                        }
                        else
                        {
                            TBlancas = true;
                        }
                        Console.ReadLine();
                        break;
                }

            } while (TBlancas);

            do
            {
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("Turno de negras");
                turnoBlancas = false; // Cambiar al turno de las negras
                Console.WriteLine("1. Mover una pieza");
                Console.WriteLine("2. Salir");
                Console.WriteLine("Opción: ");
                string option = Console.ReadLine();
                while (!ValidarNumeros(option))
                {
                    Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
                    option = Console.ReadLine();
                }
                opcion = int.Parse(option);
                while (opcion <= 0 || opcion > 3)
                {
                    Console.WriteLine("Elige una opción válida\n\n");
                    Console.ReadLine();
                    Console.ReadLine();
                    option = Console.ReadLine();
                    while (!ValidarNumeros(option))
                    {
                        Console.Write(
                                "El valor ingresado no es un entero\n\nIntente nuevamente: ");
                        option = Console.ReadLine();
                    }
                    opcion = int.Parse(option);
                }
                switch (opcion)
                {
                    case 1:
                        ImprimirTablero(tablero);
                        bool TNegraS = ElegirPiezaR(tablero, turnoBlancas);
                        if (TNegraS)
                        {
                            TNegras = true;
                        }
                        break;
                    default:
                        LimpiarConsola();

                        Console.WriteLine("Seguro que desea cerrar el programa? (1. Si/2. No)");
                        option = Console.ReadLine();
                        while (!ValidarNumeros(option))
                        {
                            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
                            option = Console.ReadLine();
                        }
                        opcion = int.Parse(option);
                        while (opcion <= 0 || opcion > 2)
                        {
                            Console.WriteLine("Elige una opción válida: ");
                            option = Console.ReadLine();
                            while (!ValidarNumeros(option))
                            {
                                Console.Write(
                                        "El valor ingresado no es un entero\n\nIntente nuevamente: ");
                                option = Console.ReadLine();
                            }
                            opcion = int.Parse(option);
                        }
                        if (opcion == 1)
                        {
                            LimpiarConsola();
                            Console.WriteLine("\t\t\t\u001B[33mGracias por jugar\n" + defaultcolor);
                            Console.WriteLine("Presiona enter para continuar...");
                            Console.ReadLine();
                            LimpiarConsola();
                            Console.WriteLine(
                                    "\t\t\t\t\u001B[33mCréditos\n\n" + defaultcolor
                                            + "* Angel Alejandro Becerra Rojas\r\n* Christian Axel Moreno Flores\r\n* Andrés Aguilera Hernández");
                            Console.WriteLine("\n\n Presiona enter para continuar...");
                            Console.ReadLine();
                            LimpiarConsola();
                            Environment.Exit(0);
                        }
                        else
                        {
                            TNegras = false;
                        }
                        Console.ReadLine();
                        break;
                }
            } while (!TNegras);

        } while (finale == false);

    }

    // Método para elegir una pieza
    private static bool ElegirPiezaR(string[,] tablero2, bool turnoBlancas)
    {
        LimpiarConsola();
        ImprimirTablero(tablero);
        Console.WriteLine("Elija la pieza que desea mover: ");
        pieza = Console.ReadLine().ToLower();
        while (!ValidarPiezaSeleccionada(pieza))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            pieza = Console.ReadLine().ToLower();
        }
        pieza = BIbliotecaR(pieza);
        Console.WriteLine(pieza);
        Console.WriteLine("Columna: ");
        string columnas = Console.ReadLine().ToUpper();
        int valF = ValidarEntrada(columnas);
        while (valF == 0)
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            columnas = Console.ReadLine().ToUpper();
            valF = ValidarEntrada(columnas);
        }
        int columna = valF;
        Console.WriteLine("Fila: ");
        string filas = Console.ReadLine();
        while (!ValidarNumeros(filas))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
            filas = Console.ReadLine();
        }
        int fila = NuevaPos(int.Parse(filas));
        Console.WriteLine("Columna a la que desea mover: ");
        string columnas2 = Console.ReadLine().ToUpper();
        int valF2 = ValidarEntrada(columnas2);
        while (valF2 == 0)
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            columnas2 = Console.ReadLine().ToUpper();
            valF2 = ValidarEntrada(columnas2);
        }
        int columna2 = valF2;
        Console.WriteLine("Fila a la que desea mover: ");
        string filas2 = Console.ReadLine();
        while (!ValidarNumeros(filas2))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
            filas2 = Console.ReadLine();
        }
        int fila2 = NuevaPos(int.Parse(filas2));

        string comp = tablero[fila, columna];
        // Obtenemos "color de la casilla y la letra de la pieza"
        // Obtenemos " p "
        string pz = BibliotecaR(pieza);
        // Obtenermos "PeonN"
        string concatenarN1 = BGB + pieza;
        string concatenarN2 = BGN + pieza;
        if ((comp.Equals(concatenarN1)) || (comp.Equals(concatenarN2)))
        {
            switch (pieza)
            {
                case " \u265D  ": // Alfil negro
                    if (MovimientoAlfil(fila, columna, fila2, columna2, tablero))
                    {
                        return MoverPiezaR(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El alfil no se puede mover a esa posición");
                        return false;
                    }
                case " \u265E  ": // Caballo negro
                    if (ValidarCaballo(fila, columna, fila2, columna2))
                    {
                        return MoverPiezaR(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El caballo no se puede mover a esa posición");
                        return false;
                    }
                case " \u265A  ": // Rey negro
                    if (ValidarRey(fila, columna, columna2, fila2))
                    {
                        return MoverPiezaR(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El rey no se puede mover a esa posición");
                    }
                    break;
                case " \u265B  ": // Dama negra
                    if (fila == fila2)
                    {
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                    else if (columna == columna2)
                    {
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                    else
                    {
                        if (MovimientoAlfil(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                default:
                    if (pieza.Equals(TorreN))
                    { // Torre y peón negros
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPiezaR(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La torre no se puede mover a esa posición");
                            return false;

                        }
                    }
                    else if (pieza.Equals(PeonN))
                    {
                        if (MovimientoPeonN(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPiezaR(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("El peón no se puede mover a esa posición");
                            return false;
                        }
                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("No puedes mover esta pieza");
            return false;
        }
        return false;

    }

    private static bool MovimientoPeonN(int fila, int columna, int fila2, int columna2, string[,] tablero2)
    {
        if (columna == columna2)
        {
            if (tablero2[1, 1] == tablero2[fila, columna] || tablero2[1, 2] == tablero2[fila, columna]
                    || tablero2[1, 3] == tablero2[fila, columna] || tablero2[1, 4] == tablero2[fila, columna]
                    || tablero2[1, 5] == tablero2[fila, columna] || tablero2[1, 6] == tablero2[fila, columna]
                    || tablero2[1, 7] == tablero2[fila, columna] || tablero2[1, 8] == tablero2[fila, columna])
            {
                if (fila2 - fila == 1)
                {
                    return true;
                }
                else if (fila2 - fila == 2)
                {
                    return true;
                }
            }
            else
            {
                if (fila2 - fila == 1)
                {
                    return true;
                }
            }
        }
        else
        {
            return false;
        }
        return false;
    }

    private static string BIbliotecaR(string pieza2)
    {
        if (pieza2.Equals("p"))
        {
            return " \u265F  ";
        }
        else if (pieza2.Equals("t"))
        {
            return " \u265C  ";
        }
        else if (pieza2.Equals("c"))
        {
            return " \u265E  ";
        }
        else if (pieza2.Equals("a"))
        {
            return " \u265D  ";
        }
        else if (pieza2.Equals("d"))
        {
            return " \u265B  ";
        }
        else if (pieza2.Equals("r"))
        {
            return " \u265A  ";
        }
        else
        {
            return "   ";
        }
    }

    private static bool MoverPiezaR(string[,] tablero2, int fila, int columna, int fila2, int columna2,
            string pieza2, bool turnoBlancas, string pz)
    {
        string pieza = tablero[fila, columna];
        if (!turnoBlancas && pz.Contains("N"))
        {
            pieza = tablero[fila, columna];
            if (pieza.Equals(BGB + pieza2))
            {
                tablero[fila, columna] = BGB + "    ";
                string pieza3 = tablero[fila2, columna2];
                if (pieza3.Equals(BGN + "    "))
                {
                    tablero[fila2, columna2] = BGN + pieza2;
                }
                else if (pieza3.Equals(BGB + "    "))
                {
                    tablero[fila2, columna2] = BGB + pieza2;

                }
                else
                {
                    Console.WriteLine("No se puede mover a esa posición");
                    return false;
                }

            }
            else if (pieza.Equals(BGN + pieza2))
            {
                tablero[fila, columna] = BGN + "    ";
                string pieza3 = tablero[fila2, columna2];
                if (pieza3.Equals(BGN + "    "))
                {
                    tablero[fila2, columna2] = BGN + pieza2;
                }
                else if (pieza3.Equals(BGB + "    "))
                {
                    tablero[fila2, columna2] = BGB + pieza2;

                }
                else
                {
                    Console.WriteLine("No se puede mover a esa posición");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No hay ninguna pieza en esa posición");
                return false;
            }

            ImprimirTablero(tablero);
            turnoBlancas = true;
        }
        else
        {
            Console.WriteLine("No es el turno de esa pieza");
            return false;
        }
        return true;
    }

    private static string BibliotecaR(string pieza2)
    {
        if (pieza2.Equals(" \u265F  "))
        {
            return "PeonN";
        }
        else if (pieza2.Equals(" \u265C  "))
        {
            return "TorreN";
        }
        else if (pieza2.Equals(" \u265E  "))
        {
            return "CaballoN";
        }
        else if (pieza2.Equals(" \u265D  "))
        {
            return "AlfilN";
        }
        else if (pieza2.Equals(" \u265B  "))
        {
            return "DamaN";
        }
        else if (pieza2.Equals(" \u265A  "))
        {
            return "ReyN";
        }
        else
        {
            return "   ";
        }
    }

    private static bool ElegirPieza(string[,] tablero, bool turnoBlancas)
    {
        LimpiarConsola();
        ImprimirTablero(tablero);
        Console.WriteLine("Elija la pieza que desea mover: ");
        pieza = Console.ReadLine().ToUpper();
        // pieza = Console.ReadLine().ToUpper();
        while (!ValidarPiezaSeleccionada(pieza))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            pieza = Console.ReadLine().ToUpper();
        }
        pieza = BIbliotecaB(pieza);
        Console.WriteLine(pieza);
        Console.WriteLine("Columna: ");
        string columnas = Console.ReadLine().ToUpper();
        int valF = ValidarEntrada(columnas);
        while (valF == 0)
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            columnas = Console.ReadLine().ToUpper();
            valF = ValidarEntrada(columnas);
        }
        int columna = valF;

        Console.WriteLine("Fila: ");
        string filas = Console.ReadLine();
        while (!ValidarNumeros(filas))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
            filas = Console.ReadLine();
        }
        int fila = NuevaPos(int.Parse(filas));
        Console.WriteLine("Columna a la que desea mover: ");
        string columnas2 = Console.ReadLine().ToUpper();
        int valF2 = ValidarEntrada(columnas2);
        while (valF2 == 0)
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon una letra válida: \u001B[0m ");
            columnas2 = Console.ReadLine().ToUpper();
            valF2 = ValidarEntrada(columnas2);
        }
        int columna2 = valF2;

        Console.WriteLine("Fila a la que desea mover: ");
        string filas2 = Console.ReadLine();
        while (!ValidarNumeros(filas2))
        {
            Console.WriteLine("\u001b[31mLa entrada no es válida, pon un número válido: \u001B[0m");
            filas2 = Console.ReadLine();
        }
        int fila2 = NuevaPos(int.Parse(filas2));

        string comp = tablero[fila, columna];
        string pz = BibliotecaB(pieza);
        // Obtenermos "PeonB"
        string concatenarN1 = BGB + pieza;
        string concatenarN2 = BGN + pieza;

        if ((comp.Equals(concatenarN1)) || (comp.Equals(concatenarN2)))
        {
            switch (pieza)
            {
                case " \u2657  ": // Alfil blanco
                    if (MovimientoAlfil(fila, columna, fila2, columna2, tablero))
                    {
                        return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El alfil no se puede mover a esa posición");
                        return false;
                    }
                case " \u2658  ": // Caballo blanco
                    if (ValidarCaballo(fila, columna, fila2, columna2))
                    {
                        return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El caballo no se puede mover a esa posición");
                        return false;
                    }
                case " \u2654  ": // Rey blanco
                    if (ValidarRey(fila, columna, columna2, fila2))
                    {
                        return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                    }
                    else
                    {
                        Console.WriteLine("El rey no se puede mover a esa posición");
                    }
                    break;
                case " \u2655  ": // Dama blanca
                    if (fila == fila2)
                    {
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                    else if (columna == columna2)
                    {
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                    else
                    {
                        if (MovimientoAlfil(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La Dama no se puede mover a esa posición");
                            return false;
                        }
                    }
                default:
                    if (pieza.Equals(TorreB))
                    { // Torre y peón blancos
                        if (MovimientoTorre(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("La torre no se puede mover a esa posición");
                            return false;

                        }
                    }
                    else if (pieza.Equals(PeonB))
                    {
                        if (MovimientoPeonB(fila, columna, fila2, columna2, tablero))
                        {
                            return MoverPieza(tablero, fila, columna, fila2, columna2, pieza, turnoBlancas, pz);
                        }
                        else
                        {
                            Console.WriteLine("El peón no se puede mover a esa posición");
                            return false;

                        }
                    }
                    break;
            }
            return false;
        }
        return false;
    }

    private static bool MovimientoPeonB(int fila, int columna, int fila2, int columna2, string[,] tablero2)
    {
        if (columna == columna2)
        {
            if (tablero2[6, 1] == tablero2[fila, columna] || tablero2[6, 2] == tablero2[fila, columna]
                    || tablero2[6, 3] == tablero2[fila, columna] || tablero2[6, 4] == tablero2[fila, columna]
                    || tablero2[6, 5] == tablero2[fila, columna] || tablero2[6, 6] == tablero2[fila, columna]
                    || tablero2[6, 7] == tablero2[fila, columna] || tablero2[6, 8] == tablero2[fila, columna])
            {
                if (fila - fila2 == 1)
                {
                    return true;
                }
                else if (fila - fila2 == 2)
                {
                    return true;
                }
            }
            else
            {
                if (fila - fila2 == 1)
                {
                    return true;
                }
            }
        }
        else
        {
            return false;
        }
        return false;
    }

    private static bool MovimientoTorre(int fila, int columna, int fila2, int columna2, string[,] tablero2)
    {
        bool continuar = false;
        if (fila == fila2)
        {
            int inicio = Math.Min(columna, columna2);
            int fin = Math.Max(columna, columna2);
            for (int i = inicio + 1; i < fin; i++)
            {
                if (tablero2[fila, i].Equals(BGB + "    ") || tablero2[fila, i].Equals(BGN + "    "))
                {
                    continuar = true;
                }
                else
                {
                    return false;
                }
            }
            if (continuar)
            {
                return true;
            }
        }
        else if (columna == columna2)
        {
            int inicio = Math.Min(fila, fila2);
            int fin = Math.Max(fila, fila2);
            for (int i = inicio + 1; i < fin; i++)
            {
                if (tablero2[i, columna].Equals(BGB + "    ") || tablero2[i, columna].Equals(BGN + "    "))
                {
                    continuar = true;
                }
                else
                {
                    return false;
                }
            }
            if (continuar)
            {
                return true;
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    private static bool ValidarRey(int fila, int columna, int columna2, int fila2)
    {
        int difFil = Math.Abs(fila - fila2);
        int difCol = Math.Abs(columna - columna2);
        return difFil <= 1 && difCol <= 1;
    }

    private static bool MovimientoAlfil(int fila, int columna, int fila2, int columna2, string[,] tablero)
    {
        // Calcular la diferencia en X y Y entre el origen y el destino
        int diffX = Math.Abs(fila - fila2);
        int diffY = Math.Abs(columna - columna2);

        // El movimiento es válido si la diferencia en X es igual a la diferencia en Y
        if (diffX != diffY)
        {
            return false;
        }

        // Determinar la dirección del movimiento
        int dirX = (fila2 - fila) / diffX;
        int dirY = (columna2 - columna) / diffY;

        // Comprobar cada casilla en la diagonal
        for (int i = 1; i <= diffX; i++)
        {
            int x = fila + i * dirX;
            int y = columna + i * dirY;

            // Si la casilla no está vacía, el movimiento no es válido
            if (tablero[x, y].Equals(BGB + "    ") || tablero[x, y].Equals(BGN + "    "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Si todas las casillas en la diagonal están vacías, el movimiento es válido
        return true;
    }

    private static bool ValidarCaballo(int fila, int columna, int fila2, int columna2)
    {
        int difFil = Math.Abs(fila - fila2);
        int difCol = Math.Abs(columna - columna2);
        return (difFil == 2 && difCol == 1) || (difFil == 1 && difCol == 2);
    }

    private static string BIbliotecaB(string pieza2)
    {
        if (pieza2.Equals("P"))
        {
            return " \u2659  ";
        }
        else if (pieza2.Equals("T"))
        {
            return " \u2656  ";
        }
        else if (pieza2.Equals("C"))
        {
            return " \u2658  ";
        }
        else if (pieza2.Equals("A"))
        {
            return " \u2657  ";
        }
        else if (pieza2.Equals("D"))
        {
            return " \u2655  ";
        }
        else if (pieza2.Equals("R"))
        {
            return " \u2654  ";
        }
        else
        {
            return "   ";
        }
    }

    private static int NuevaPos(int filas)
    {
        switch (filas)
        {
            case 1:
                return 7;
            case 2:
                return 6;
            case 3:
                return 5;
            case 4:
                return 4;
            case 5:
                return 3;
            case 6:
                return 2;
            case 7:
                return 1;
            default:
                return 0;
        }
    }

    private static int ValidarEntrada(string fila)
    {
        bool match = Regex.IsMatch(fila, "[A-H]");
        if (match)
        {
            switch (fila)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                default:
                    return 0;
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida");
            return 0;
        }
    }

    private static string BibliotecaB(string pz)
    {
        if (pz.Equals(" \u2659  "))
        {
            return "PeonB";
        }
        else if (pz.Equals(" \u2656  "))
        {
            return "TorreB";
        }
        else if (pz.Equals(" \u2658  "))
        {
            return "CaballoB";
        }
        else if (pz.Equals(" \u2657  "))
        {
            return "AlfilB";
        }
        else if (pz.Equals(" \u2655  "))
        {
            return "DamaB";
        }
        else if (pz.Equals(" \u2654  "))
        {
            return "ReyB";
        }
        else
        {
            return "   ";
        }
    }

    private static bool MoverPieza(string[,] tablero, int fila, int columna, int fila2, int columna2, string pieza2,
            bool turnoBlancas, string pz)
    {
        string pieza = tablero[fila, columna];
        // string pz = BibliotecaB(pieza2);
        if (turnoBlancas && pz.Contains("B"))
        { // Si es el turno de las blancas y la pieza es blanca
            pieza = tablero[fila, columna];
            if (pieza.Equals(BGB + pieza2))
            {
                tablero[fila, columna] = BGB + "    ";
                string pieza3 = tablero[fila2, columna2];
                if (pieza3.Equals(BGN + "    "))
                {
                    tablero[fila2, columna2] = BGN + pieza2;
                }
                else if (pieza3.Equals(BGB + "    "))
                {
                    tablero[fila2, columna2] = BGB + pieza2;

                }
                else
                {
                    Console.WriteLine("No se puede mover a esa posición");
                    return false;
                }

            }
            else if (pieza.Equals(BGN + pieza2))
            {
                tablero[fila, columna] = BGN + "    ";
                string pieza3 = tablero[fila2, columna2];
                if (pieza3.Equals(BGN + "    "))
                {
                    tablero[fila2, columna2] = BGN + pieza2;
                }
                else if (pieza3.Equals(BGB + "    "))
                {
                    tablero[fila2, columna2] = BGB + pieza2;

                }
                else
                {
                    Console.WriteLine("No se puede mover a esa posición");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No hay ninguna pieza en esa posición");
                return false;
            }

            ImprimirTablero(tablero);
            turnoBlancas = false; // Cambiar al turno de las negras
        }
        else
        {
            Console.WriteLine("No es el turno de esa pieza");
            return false;
        }
        return true;
    }

    private static string[,] ImprimirTablero(string[,] tablero)
    {
        // Imprimir el tablero
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(tablero[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine(
                "\n \u001B[33mP = \u2659 (Peón) \t T = \u2656 (Torre) \t C = \u2658 (Caballo) \n A = \u2657 (Alfil) \t D = \u2655 (Dama) \t R = \u2654 (Rey) \n"
                        + defaultcolor);

        return tablero;
    }

    private static string[,] CrearTablero()
    {
        string[,] tablero = new string[9, 10];

        tablero[0, 0] = " 8 ";
        tablero[0, 1] = BGB + TorreN;
        tablero[0, 2] = BGN + CaballoN;
        tablero[0, 3] = BGB + AlfilN;
        tablero[0, 4] = BGN + DamaN;
        tablero[0, 5] = BGB + ReyN;
        tablero[0, 6] = BGN + AlfilN;
        tablero[0, 7] = BGB + CaballoN;
        tablero[0, 8] = BGN + TorreN;
        tablero[0, 9] = BG;

        tablero[1, 0] = " 7 ";
        tablero[1, 1] = BGN + PeonN;
        tablero[1, 2] = BGB + PeonN;
        tablero[1, 3] = BGN + PeonN;
        tablero[1, 4] = BGB + PeonN;
        tablero[1, 5] = BGN + PeonN;
        tablero[1, 6] = BGB + PeonN;
        tablero[1, 7] = BGN + PeonN;
        tablero[1, 8] = BGB + PeonN;
        tablero[1, 9] = BG;

        tablero[2, 0] = " 6 ";
        tablero[2, 1] = BGB + "    ";
        tablero[2, 2] = BGN + "    ";
        tablero[2, 3] = BGB + "    ";
        tablero[2, 4] = BGN + "    ";
        tablero[2, 5] = BGB + "    ";
        tablero[2, 6] = BGN + "    ";
        tablero[2, 7] = BGB + "    ";
        tablero[2, 8] = BGN + "    ";
        tablero[2, 9] = BG;

        tablero[3, 0] = " 5 ";
        tablero[3, 1] = BGN + "    ";
        tablero[3, 2] = BGB + "    ";
        tablero[3, 3] = BGN + "    ";
        tablero[3, 4] = BGB + "    ";
        tablero[3, 5] = BGN + "    ";
        tablero[3, 6] = BGB + "    ";
        tablero[3, 7] = BGN + "    ";
        tablero[3, 8] = BGB + "    ";
        tablero[3, 9] = BG;

        tablero[4, 0] = " 4 ";
        tablero[4, 1] = BGB + "    ";
        tablero[4, 2] = BGN + "    ";
        tablero[4, 3] = BGB + "    ";
        tablero[4, 4] = BGN + "    ";
        tablero[4, 5] = BGB + "    ";
        tablero[4, 6] = BGN + "    ";
        tablero[4, 7] = BGB + "    ";
        tablero[4, 8] = BGN + "    ";
        tablero[4, 9] = BG;

        tablero[5, 0] = " 3 ";
        tablero[5, 1] = BGN + "    ";
        tablero[5, 2] = BGB + "    ";
        tablero[5, 3] = BGN + "    ";
        tablero[5, 4] = BGB + "    ";
        tablero[5, 5] = BGN + "    ";
        tablero[5, 6] = BGB + "    ";
        tablero[5, 7] = BGN + "    ";
        tablero[5, 8] = BGB + "    ";
        tablero[5, 9] = BG;

        tablero[6, 0] = " 2 ";
        tablero[6, 1] = BGB + PeonB;
        tablero[6, 2] = BGN + PeonB;
        tablero[6, 3] = BGB + PeonB;
        tablero[6, 4] = BGN + PeonB;
        tablero[6, 5] = BGB + PeonB;
        tablero[6, 6] = BGN + PeonB;
        tablero[6, 7] = BGB + PeonB;
        tablero[6, 8] = BGN + PeonB;
        tablero[6, 9] = BG;

        tablero[7, 0] = " 1 ";
        tablero[7, 1] = BGN + TorreB;
        tablero[7, 2] = BGB + CaballoB;
        tablero[7, 3] = BGN + AlfilB;
        tablero[7, 4] = BGB + ReyB;
        tablero[7, 5] = BGN + DamaB;
        tablero[7, 6] = BGB + AlfilB;
        tablero[7, 7] = BGN + CaballoB;
        tablero[7, 8] = BGB + TorreB;
        tablero[7, 9] = BG;

        tablero[8, 0] = "    ";
        tablero[8, 1] = " A  ";
        tablero[8, 2] = " B  ";
        tablero[8, 3] = " C  ";
        tablero[8, 4] = " D  ";
        tablero[8, 5] = " E  ";
        tablero[8, 6] = " F  ";
        tablero[8, 7] = " G  ";
        tablero[8, 8] = " H  ";
        tablero[8, 9] = "    ";

        return tablero;
    }
}
