Imports CarLibrary
Module Module1

    Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App")

        ' Локальные переменные объявлены с применением ключевого слова Dim
        Dim myMiniVan As New MiniVan()
        myMiniVan.TurboBoost()

        Dim mySportsCar As New SportsCar()
        mySportsCar.TurboBoost()

        Dim dreamCar As New PerformanceCar()
        ' Использовать унаследованное свойство
        dreamCar.PetName = "Hank"
        dreamCar.TurboBoost()

        Console.ReadLine()
    End Sub

End Module
