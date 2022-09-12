using BenchmarkDotNet.Running;
using String_Vs_StringBuilder;
using System;
using System.Numerics;
using System.Text;
//1st run to eliminate any startup overhead
//StringManager.MeasureA();
//StringManager.MeasureB();
////measurement run
//long duration1 = StringManager.MeasureA();
//long duration2 = StringManager.MeasureB();
////display results
//Console.WriteLine($"String performance: {duration1} milliseconds");
//Console.WriteLine($"StringBuilder performance: {duration2} milliseconds");
//var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
BenchmarkRunner.Run<StringManagerBenchmark>();