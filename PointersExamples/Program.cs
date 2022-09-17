using BenchmarkDotNet.Running;
using PointersExamplesImagesManipulation;

//The test with pseudo img are not running well, the results are not valid
BenchmarkRunner.Run<ImageManagerBenchmark>();