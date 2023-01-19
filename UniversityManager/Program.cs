namespace UniversityManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] someInts = new int[] { 32, 64, 63, 83, 27, 47, 94 };

            IEnumerable<int> ints = from i in someInts orderby i select i;
            IEnumerable<int> reversedInts = ints.Reverse();
            foreach (int i in reversedInts)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> reversedInts2 = from i in someInts orderby i descending select i;
            foreach (int i in reversedInts2)
            {
                Console.WriteLine(i);
            }

            UniversitiesManagerr um = new UniversitiesManagerr();
            um.MaleStudents();
            um.FemaleStudents();
            um.StudentsByAge();
            um.AllStudentsFromAptech();

            Console.WriteLine("*******************************");
            Console.WriteLine("There are 3 universities with Id 1, 2 and 3");
            Console.WriteLine("Please iput Id of University that you want to see infomation" +
                " of its Students");
            string input = Console.ReadLine();
            try
            {
                int Id = Convert.ToInt32(input);
                um.AllStudentsFromThatUni(Id);
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong input!");
            }

            um.StudentAndUniversityNameCollection();

            Console.ReadLine();
        }
    }
}