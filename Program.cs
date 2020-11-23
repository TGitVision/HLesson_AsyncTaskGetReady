using System;
using System.Threading;
using System.Threading.Tasks;

namespace HLesson_AsyncTaskGetReady
{
    class Program
    {

        //public DateTime StartDateTime;

        //public DateTime EndDateTime;

        static void Main(string[] args)
        {


            ReadyToGo.TargetPassengerCount = 5;
            ReadyToGo.StartDateTime = DateTime.Now;

            AlarmGoesOff();

            // Least Efficient: Before common method: PersonReadyToGo(Person person)
            // Doesn't adhere to DRY.
            // Method1(); 

            // Most Efficient: Consolidated repeating methods to: PersonReadyToGo(Person person)
            Method2();  

        }

        // Redone with DRY in mind. See common PersonReadyToGo(Person person).
        public static void Method1()
        {

            MomGetsReady();

            DadGetsReady();

            BestFriendGetsReady();

            BigBrotherGetsReady();

            LittleBrotherGetsReady();

            Console.ReadLine();

            ////bool bResult = LittleBrotherGetsReady().Result;
            ////if (bResult == true) 
            ////{ 
            ////    RideToSchool();            
            ////}
            ////Console.ReadLine();

        }
        public static void Method2()
        {


            Person mom = new Person();
            mom.FamilyTitle = "Mom";
            mom.ReadyTimeInterval = 10000;
            PersonReadyToGo(mom);

            Person dad = new Person();
            dad.FamilyTitle = "Dad";
            dad.ReadyTimeInterval = 8000;
            PersonReadyToGo(dad);

            Person bigBrother = new Person();
            bigBrother.FamilyTitle = "Big Bro";
            bigBrother.ReadyTimeInterval = 12000;
            PersonReadyToGo(bigBrother);

            Person lilBrother = new Person();
            lilBrother.FamilyTitle = "Lil' Bro";
            lilBrother.ReadyTimeInterval = 14000;
            PersonReadyToGo(lilBrother);

            Person bestFriend = new Person();
            bestFriend.FamilyTitle = "Best Friend";
            bestFriend.ReadyTimeInterval = 30000;
            PersonReadyToGo(bestFriend);

            Console.ReadLine();

        }

        public static void AlarmGoesOff()
        {
            
            Console.WriteLine($"Alarm goes off at {DateTime.Now}. \n");

        }        

        // Note: Asynchronously runs when you DON'T return value as a Task in signature.
        public static async void MomGetsReady()
        {

            // ready seconds
            int intReadyTimeInterval = 2000;
            int intReadySecs = GetSeconds(intReadyTimeInterval);

            await Task.Run(() =>
            {

                Thread.Sleep(intReadyTimeInterval);
                Console.WriteLine($"Mom gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();
                
            });
        }

        // Note: Asynchronously runs when you DON'T return value as a Task in signature.
        public static async void DadGetsReady()
        {
            // ready seconds
            int intReadyTimeInterval = 5000;
            int intReadySecs = GetSeconds(intReadyTimeInterval);

            await Task.Run(() =>
            {

                Thread.Sleep(intReadyTimeInterval);
                Console.WriteLine($"Dad gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();
                
            });
        }

        // Note: Asynchronously runs when you DON'T return value as a Task in signature.
        public static async void BigBrotherGetsReady()
        {
            // ready seconds
            int intReadyTimeInterval = 6000;
            int intReadySecs = GetSeconds(intReadyTimeInterval);

            await Task.Run(() =>
            {

                Thread.Sleep(intReadyTimeInterval);
                Console.WriteLine($"Big brother gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();
                
            });
        }

        // Note: Asynchronously runs when you DON'T return value as a Task in signature.
        public static async void LittleBrotherGetsReady()
        {
            // ready seconds
            int intReadyTimeInterval = 2000;
            int intReadySecs = GetSeconds(intReadyTimeInterval);

            await Task.Run(() =>
            {

                Thread.Sleep(intReadyTimeInterval);
                Console.WriteLine($"Little brother gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();
                
            });
        }

        // Note: Synchronously runs when you return value in Task.

        //public static async Task<bool> LittleBrotherGetsReady()
        //{
        //    // ready seconds
        //    int intReadySecs = 12000;

        //    bool blnResult = false;
        //    await Task.Run(() =>
        //    {

        //        Thread.Sleep(intReadySecs);
        //        Console.WriteLine($"Little brother gets ready in {intReadySecs} secs.");
        //        blnResult = true;
        //        ReadyToGo.MorningPassengerCount += 1;
        //        Console.WriteLine($"Morning Passenger Count {ReadyToGo.MorningPassengerCount}.");
        //        ReadyToGo.IsReadyYet();

        //    });
        //    return blnResult;
        //}

        public static async void BestFriendGetsReady()
        {
            // ready seconds
            int intReadyTimeInterval = 4000;
            int intReadySecs = GetSeconds(intReadyTimeInterval);

            await Task.Run(() =>
            {

                Thread.Sleep(intReadyTimeInterval);
                Console.WriteLine($"Best friend gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();

            });
        }

        public static int GetSeconds(int intTimeInterval)
        {

            return (intTimeInterval / 1000);

        }

        public static async void PersonReadyToGo(Person person)
        {

            // ready seconds

            await Task.Run(() =>
            {

                int intReadySecs = GetSeconds(person.ReadyTimeInterval);
                Thread.Sleep(person.ReadyTimeInterval);
                Console.WriteLine($"{person.FamilyTitle} gets ready in {intReadySecs} secs.");
                ReadyToGo.MorningPassengerCount += 1;
                ReadyToGo.ArePassengersReadyToGoYet();

            });

        }

    }
}
