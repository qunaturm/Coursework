using System.Text;
using System.Threading.Tasks.Dataflow;
using Coursework;

var matrix = new int[] { 2, 3, 3, 4, 1, 0 };
var matrixRows = 3;
var matrixColumns = 2;
var minorSize = 2;

var buffer = new BufferBlock<(int, int)[]>();

var minorBuilder = new TransformBlock<(int, int)[], int[]>(minorSpec =>
    {
        var minor = new int[minorSize * minorSize];
        MatrixCoordinator.BuildMinor(matrix, matrixRows, minorSpec, ref minor, minorSize);
        return minor;
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 }
);

var strBuilder = new TransformBlock<int[], string>(minor =>
{
    int i = 0, j = 0;
    var str = new StringBuilder();

    minor.ToList().ForEach(u =>
    {
        str.Append($"|{u}|");
        i++;
        if (i >= minorSize)
        {
            str.AppendLine("\n============================");
            i = 0;
            j++;
        }
    });
    str.AppendLine("\n-------------------------");
    return str.ToString();
}, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1});
var strBuffer = new BufferBlock<string>();

var consoleWriter = new ActionBlock<string>(str => Console.WriteLine(str), new ExecutionDataflowBlockOptions
{
    MaxDegreeOfParallelism = 1,
    SingleProducerConstrained = true
});

buffer.LinkTo(minorBuilder);
minorBuilder.LinkTo(strBuilder);
strBuilder.LinkTo(strBuffer);
strBuffer.LinkTo(consoleWriter);
buffer.Completion.ContinueWith(task => minorBuilder.Complete());
minorBuilder.Completion.ContinueWith(task => strBuilder.Complete());
strBuilder.Completion.ContinueWith(task => strBuffer.Complete());
strBuffer.Completion.ContinueWith(task => consoleWriter.Complete());




var minors = MinorCoordinator.GetMinors(matrixRows, matrixColumns, minorSize);

foreach (var col in minors)
{
    buffer.Post(col);
}

buffer.Complete();
consoleWriter.Completion.Wait();
