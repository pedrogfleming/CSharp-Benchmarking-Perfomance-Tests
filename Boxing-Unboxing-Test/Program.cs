using Boxing_Unboxing_Test;
//1st run to eliminate any startup overhead
MeasureTest.MeasureA();
MeasureTest.MeasureB();

// measurement run
long intDuration = MeasureTest.MeasureA();
long objDuration = MeasureTest.MeasureB();

//display results
Console.WriteLine($"Integer performance {intDuration} microseconds");
Console.WriteLine($"Object performance {objDuration} microseconds\n");
long ratio = (long)(1.0 * objDuration / intDuration);
Console.WriteLine($"Method B is {ratio} times slower");
