﻿



//Func<int, int, int> sub = ( a, b) => a - b;


//Func<int, int> some = (a) => a * 2;

//Func<int, int> some2 = (a) =>
//{
//    a = a + 1;
//    return a * 5;
//};



//sub(2 , 3);
//some(2);
//some2(2);



Some ((a, b)=> a +b, 5);

void Some (Func<int, int, int > fn, int number)
{
    var result = fn(number, number); 
}