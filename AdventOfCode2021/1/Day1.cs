namespace AdventOfCode2021._1;

public class Day1 : AbstractDay
{
    public Day1() : base(1) 
    {
    }

    protected override void SolveA()
    {
        var measurements = FileReader.ReadWithNewLines().ConvertToIntegerEnumerable();
        var previousMeasurement = 0;
        var amountOfMeasurements = 0;

        foreach(var measurement in measurements)
        {
            if (previousMeasurement != 0 && measurement > previousMeasurement) amountOfMeasurements++;
            previousMeasurement = measurement;
        }

        Console.WriteLine(amountOfMeasurements);
    }

    protected override void SolveB()
    {
        var measurements = FileReader
            .ReadWithNewLines()
            .ConvertToIntegerEnumerable()
            .ToList();
        var previousSum = 0;
        var amountOfMeasurements = 0;

        foreach(var (measurement, index) in measurements.Select((x, i) => (x, i)))
        {
            try
            {
                var firstMeasurement = measurements[index];
                var secondMeasurement = measurements[index + 1];
                var thirdMeasurement = measurements[index + 2];
                var sum = firstMeasurement + secondMeasurement + thirdMeasurement;

                if (previousSum != 0 && sum > previousSum) amountOfMeasurements++;
                previousSum = sum;
            }
            catch(ArgumentOutOfRangeException)
            {
                break;
            }
        }

        Console.WriteLine(amountOfMeasurements);
    }
}
