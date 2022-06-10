using Microsoft.VisualStudio.TestTools.UnitTesting;
using Övning5Garage;
using System;

namespace Övning5GarageTest
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void GarageIndexIsOutOfRangeExceptionMessageTestMethod()
        {
            /* Detta är ett test som kollar att vårat program slänger ett undantag
            om vi försöker komma åt ett fordon som är utanför den angivna kapaciteten.*/


            // Arrange

            // Skapar ett garage med en kapacitet av 3
            Garage<Vehicle> ts = new Garage<Vehicle>(3);

            // Skapar 5 fordon av typen Car
            Car car1 = new Car("test1", "yellow", 4, FuelType.Petrol95);
            Car car2 = new Car("test2", "red", 4, FuelType.Petrol98);
            Car car3 = new Car("test3", "blue", 4, FuelType.Diesel);
            Car car4 = new Car("test4", "green", 4, FuelType.Petrol95);
            Car car5 = new Car("test5", "orange", 4, FuelType.Petrol98);

            // Lägger till de 5 fordonen i vårt nyligen skapade garage
            ts.Add(car1);
            ts.Add(car2);
            ts.Add(car3);
            ts.Add(car4);
            ts.Add(car5);

            // Act

            /* Såklart eftersom att vi har en kapacitet av 3 så kommer vår interna array bara ha 3 positioner.
            Därav så kommer vi inte kunna komma åt car4 eller car5. Därav använder vi ts[4].DisplayVehicleDetails()
            för att komma åt det 5:e fordonet eftersom att vi börjar på 0*/

            /*Samma sak gäller om jag skriver att indexen är 3 för då försöker vi komma åt det fjärde fordonet/positionen
            vilket inte finns. Däremot om jag skriver att indexen är 2 så kommer vi åt position 3. Eftersom att
            den interna arrayen har 3 positioner så kommer testet att misslyckas. Detta för att den inte kommer att
            kasta något undantag (exception). I den situationen så kommer allting att stämma men här förväntar vi oss
            att den ska kasta ett undantag så att vi vet att vi inte kan lägga till mer fordon än vad våran 
            kapacitet anger.*/

            var actual = Assert.ThrowsException<IndexOutOfRangeException>(() => ts[4].DisplayVehicleDetails());

            // Assert

            /* Här kollar vi så att meddelandet som undantaget slänger ut stämmer överens eller är lika med
            strängen som vi har angett.*/

            Assert.AreEqual(actual.Message, "Index was outside the bounds of the array.");
        }
    }
}