// See https://aka.ms/new-console-template for more information
using EdiEngine;
using EdiEngine.Runtime;

Console.WriteLine("Hello, World!");
string edi =
@"ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00400*000003438*0*P*>
GS*OW*7705551212*3111350000*20000128*0557*3317*T*004010
ST*940*0001
W05*N*538686**001001*538686
LX*1
W01*12*CA*000100000010*VN*000100*UC*DEC0199******19991205
G69*11.500 STRUD BLUBRY
W76*56*500*LB*24*CF
SE*7*0001
GE*1*3317
IEA*1*000003438";
 EDI(edi);

static void EDI(string edi)
{


    EdiDataReader r = new EdiDataReader();
    EdiBatch ediBatch = r.FromString(edi);

    //control whether you need to accept all transaction or report error if such.
    AckBuilderSettings ackSettings = new AckBuilderSettings(AckValidationErrorBehavour.AcceptAll, false, 100, 200);
    var ack = new AckBuilder(ackSettings);

    //create FA object structure
    EdiBatch ackBatch = ack.GetnerateAcknowledgment(ediBatch);

    //Or create ack string/stream 
    string data = ack.WriteToString(ediBatch);

    Console.WriteLine(data);
    Console.ReadLine();
}