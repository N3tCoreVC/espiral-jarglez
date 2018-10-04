using System;

namespace espiral_jarglez
{
    class Program
    {
        private readonly int tamano;
        public Program(int tamano) {
            this.tamano = tamano;
            imprimir(generaString(generaEspiral(tamano)));
        }

        private int numeroMaximo(int tamano) {
            int res = tamano;
            for (int i = 1; i < tamano; i++) {
                res = res + (tamano - i);
            }
            return res;
        }
                
        private int numeroCharacteresMaximo(int tamano) {
            return Convert.ToString(numeroMaximo(tamano)).Length;
        }

        private int[,] generaEspiral(int tamano) {
            int[,] resultado = new int[tamano,tamano];
            int posicionX = 0;
            int posicionY = 0;
            int longitud = tamano;
            int numeroEspiral = 1;
            do {
                // Derecha suma en X
                for (int longEscrita = 1; longEscrita <= longitud; longEscrita++) {                   
                    resultado[posicionX,posicionY] = numeroEspiral;                    
                    posicionX++;                    
                    numeroEspiral++;
                }
                posicionX--;
                posicionY++;
                longitud--;
                if (longitud < 1) break;
                // Abajo suma en Y
                for (int longEscrita = 1; longEscrita <= longitud; longEscrita++) {
                    resultado[posicionX,posicionY] = numeroEspiral;                    
                    posicionY++;                    
                    numeroEspiral++;
                }
                posicionX--;
                posicionY--;
                longitud--;
                if (longitud < 1) break;
                // Izquierda resta en X 
                for (int longEscrita = 1; longEscrita <= longitud; longEscrita++) {
                    resultado[posicionX,posicionY] = numeroEspiral;
                    posicionX--;                    
                    numeroEspiral++;
                }
                posicionX++;
                posicionY--;
                longitud--;
                if (longitud < 1) break;
                // Arriba resta en Y
                for (int longEscrita = 1; longEscrita <= longitud; longEscrita++) {
                    resultado[posicionX,posicionY] = numeroEspiral;
                    posicionY--;                    
                    numeroEspiral++;
                }
                posicionX++;
                posicionY++;
                longitud--;
                if (longitud < 1) break;
            } while (numeroEspiral <= numeroMaximo(tamano));
            return resultado;
        }

        private string completarCeros(int numero, int completar) {
            string resultado = Convert.ToString(numero);
            while (resultado.Length < completar) {
                    resultado = "0" + resultado;
            }   
            return resultado;
        }

        private string completarEspacios(int numero) {
            string salida = "";
            while (salida.Length < numero) {
                    salida = " " + salida;
            }  
            return salida;
        }

         private string[] generaString(int[,] arreglo) {
            string cadena;
            int pixelTam = numeroCharacteresMaximo(this.tamano);
            string[] respuesta = new string[arreglo.GetLength(1)];
            for (int y = 0; y < arreglo.GetLength(1); y++) {
                cadena = "";                
                for (int x = 0; x < arreglo.GetLength(0); x++ ){
                    if (arreglo[x,y] > 0) {
                        cadena += completarCeros(arreglo[x,y],pixelTam) + " ";
                    } else if (arreglo[x,y] < 1) {
                        cadena += completarEspacios(pixelTam) + " ";
                    }
                }
                respuesta[y] = cadena;
            }
            return respuesta;
        }

        private void imprimir(string[] lineas) {
            int anchoMaximo = lineas[lineas.Length-1].Length;
            int espacios = anchoMaximo/2;
            for (int i = 0; i < lineas.Length; i++) {                              
                Console.WriteLine(lineas[i]);
            }          
        }

        static void Main(string[] args)
        {
            Console.ResetColor();
            int ancho = 0;
            Console.Write("¿De qué tamaño será el brazo más grande de tu " + 
                            "espiral tu espiral? ");
            try { 
                ancho = Int32.Parse(Console.ReadLine());
                if (ancho < 5) throw new Exception();
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Imprimes el espiral
                Console.WriteLine();
                Program espiral = new Program(ancho);
                Console.WriteLine();
                // Terminas de imprimir espiral
            } catch (Exception) { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Solo puedes escribir enteros y tiene que ser"
                                    + " mayor a 4. OTROS ERRORES TAMBIEN.");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Presiona enter para continuar ...");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
