#include<iostream>
#define DllExport _declspec(dllexport)
using namespace std;

extern "C"
{
    DllExport int AddNumbers(int a, int b) { return a + b; }
    DllExport int SubtractNumbers(int a, int b) { return a - b; }
    DllExport string WhatsMyName(string firstName, string lastName) 
    { 
        return firstName + " " + lastName; 
    }
}
