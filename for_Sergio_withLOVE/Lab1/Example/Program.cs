using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AeroDataContext();


            void method1_a()
            {
                var query = from info in db.Trip select info;
                foreach (var i in query)
                {
                    Console.WriteLine($"{i.ID_comp} {i.plane} {i.town_from} {i.town_to} {i.time_out} --- {i.time_in}");
                }
            }

            void method1_b()
            {
                Console.WriteLine("Ведите Id компании");
                string input = Console.ReadLine();

                var query = from info in db.Trip select info;
                var trips = query.Where(c => c.ID_comp == int.Parse(input));

                foreach (var trip in trips)
                {
                    Console.WriteLine($"{trip.ID_comp} {trip.plane} {trip.town_from} {trip.town_to} {trip.time_out} --- {trip.time_in}");
                }
                Console.ReadKey();
            }

            void method2()
            {
                Console.WriteLine("Ведите число A");
                string inputA = Console.ReadLine();
                Console.WriteLine("Ведите число B");
                string inputB = Console.ReadLine();

                var query = from a in db.Trip select a;

                var tripToDelete = query.Where(c => (c.ID_comp >= int.Parse(inputA) && c.ID_comp <= int.Parse(inputB)));

                db.Trip.DeleteAllOnSubmit(tripToDelete);
                db.SubmitChanges();

                foreach (var i in query)
                {
                    Console.WriteLine($"{i.ID_comp} {i.trip_no} {i.plane} {i.town_from} {i.town_to} {i.time_out} --- {i.time_in}");
                }
                Console.ReadKey();
            }

            void method3()
            {
                Console.WriteLine("Введите инфориацию о новом trip через запятую");
                string input = Console.ReadLine();
                string[] infoTrip = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var newTrip = new Trip()
                {
                    trip_no = int.Parse(infoTrip[0]),
                    ID_comp = int.Parse(infoTrip[1]),
                    plane = infoTrip[2],
                    town_from = infoTrip[3],
                    town_to = infoTrip[4],
                    time_out = DateTime.Now,
                    time_in = DateTime.Now.AddHours(1)
                };

                db.Trip.InsertOnSubmit(newTrip);
                db.SubmitChanges();

                var query = from info in db.Trip select info;

                foreach (var i in query)
                {
                    Console.WriteLine($"{i.ID_comp} {i.trip_no} {i.plane} {i.town_from} {i.town_to} {i.time_out} --- {i.time_in}");
                }
                Console.ReadKey();
            }

            method3();
            //var query = from c in db.Passenger
            //            where c.ID_psg == 16
            //            select c.name;

            //foreach (var q in query)
            //{
            //    Console.WriteLine(q);
            //}
            //Console.ReadKey();

            //var p = new Passenger
            //{
            //    ID_psg = 38,
            //    name = "Vasily Pupkin"
            //};
            //db.Passenger.InsertOnSubmit(p);
            //db.SubmitChanges();

            //var query = from c in db.Passenger
            //            select c.name;
            //foreach (var q in query)
            //{
            //    Console.WriteLine(q);
            //}
            //Console.ReadKey();

            //var query = from c in db.Passenger
            //            select c;
            //// обходим все строки из таблицы 
            //foreach (var q in query)
            //{
            //    if (q.ID_psg == 38)
            //    {
            //        q.name = "Barack Obama";
            //    }
            //}
            //// отправляем изменения на сервер 
            //db.SubmitChanges();
            //// запрос на чтение данных 
            //query = from c in db.Passenger
            //        select c;
            //// вывод содержимого таблицы 
            //foreach (var q in query)
            //{
            //    Console.WriteLine(q.ID_psg + ". " + q.name);
            //}
            //Console.ReadKey();

            // выбираем из таблицы пассажира с индексом 38
            //var query = from c in db.Passenger
            //            where c.ID_psg == 38
            //            select c;
            //foreach (var q in query)
            //{
            //    db.Passenger.DeleteOnSubmit(q);  // ставим в очередь на удаление
            //}
            //db.SubmitChanges();
            //query = from c in db.Passenger
            //        select c;
            //foreach (var q in query)
            //{
            //    Console.WriteLine(q.ID_psg + ". " + q.name);
            //}
            //Console.ReadKey();
        }
    }
}
