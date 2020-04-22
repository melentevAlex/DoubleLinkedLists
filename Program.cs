using System;

namespace DoubleLinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> mylist = new MyList<string>();
            mylist.AppEnd("23");
            mylist.AppEnd("34");
            mylist.AppEnd("45");
            mylist.AppEnd("53");
            mylist.AppEnd("67");
            mylist.AppEnd("79");
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

            mylist.Add("747", 6);


            Console.WriteLine();

            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            mylist.DeleteByIndex(6);
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }





            //MyList<string> Myliiist = new MyList<string>();
            //Myliiist[0] = new Element<string> { Data = "someData" };
            //Myliiist.AppEnd("someDataESHO");
            //Element<string> elem = Myliiist[0];
            //Console.WriteLine(elem.Data);





            /*
            for (int i = 0; i < mylist.Lenght; i++)
            {
                Console.WriteLine(mylist[i].Data);  
            }
            */
            // сделать индексатор ,чтобы работало mylist[i] 
            // метод добавления по номеру элемента 

            //Console.WriteLine(mylist[2]);
            /*
            mylist.Delete("23");
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }
            */

        }

    }
}
