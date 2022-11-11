using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace practica1
{
    class Program
    {
        public static long cuenta = 0;
        public static long salida = 0;
        static Semaphore sem = new Semaphore(1,2);//SEmaforo
        static void Main(string[] args)
        {
            Thread t1 = new Thread(entrada1);
            Thread t2 = new Thread(entrada2);
            Thread t3 = new Thread(entrada3);
            Thread t4 = new Thread(salida1);

            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(60);//Se manda a dormir el libro
            

            Console.WriteLine(cuenta);

            Console.ReadKey();
            

        }
        
        public static void entrada1()
        {
            sem.WaitOne();// semaforo se usa da incio
            //Declaraciòn desde un principio, por que es un compilador
            for (long i = 0; i < 100000 ; i++)
            {
                cuenta++;
                
            }
            sem.Release();// semaforo se usa da fin
            for (long j = 0; j < 100000; j++)
            {
                salida++;
            }


        }
        public static void entrada2()
        {
            sem.WaitOne();
            for (long i = 0; i < 100000; i++)
            {
                cuenta++;
            }
            sem.Release();
        }
        public static void entrada3()
        {
            sem.WaitOne();
            for (long i = 0; i < 100000; i++)
            {
                cuenta++;
            }
            sem.Release();
            
        }

        public static void salida1()
        {
            for (long j = 0; j < 100000; j++)
            {
                salida++;
            }


        }




    }
}
