//Name：MultiselectTransformDemo 
//Summary：TransformAndReturnString
//Maker：zzf 
//Make time：201512071602
//Other： 
//-------------------------------------------- 
//No     Editor     UpdateTime       Note 

using System.Collections.Generic;
using WFA_MultiselectTransform;

namespace WFA_MultiselectTransform_Demo
{
    public class MultiselectTransformDemo : MultiselectTransformObject
    {
        public MultiselectTransformDemo(List<bool> bollist) : base(bollist)
        {
            base.AddMethod(0, Test0);
            base.AddMethod(1, Test1);
            base.AddMethod(2, Test2);
            base.AddMethod(3, Test3);
            base.AddMethod(4, Test4);
        }

        //Test0
        private void Test0(ref object e)
        {
            e = "This is Test0! ";
        }

        //Test1
        private void Test1(ref object e)
        {
            e = "This is Test1! ";
        }

        //Test2
        private void Test2(ref object e)
        {
            e = "This is Test2! ";
        }

        //Test3
        private void Test3(ref object e)
        {
            object c = new object();
            Test1(ref c);
            Test2(ref e);
            e = (string)c +(string)e;
        }

        //Test4
        private void Test4(ref object e)
        {
            e = "This is Test4! ";
        }
    }
}
