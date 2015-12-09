//Name：MultiselectTransformObject 
//Summary：TransformObject  
//Maker：zzf 
//Make time：201512071602
//Other： 
//-------------------------------------------- 
//No     Editor     UpdateTime       Note 

using System;
using System.Collections.Generic;

namespace WFA_MultiselectTransform
{
    public abstract class MultiselectTransformObject
    {
        private List<bool> _bollist;
        private Dictionary<int, _delmethod> _methodlist;
        protected delegate void _delmethod(ref object e);

        public MultiselectTransformObject(List<bool> bollist)
        {
            if (bollist != null)
            {
                _bollist = bollist;
                _methodlist = new Dictionary<int, _delmethod>();
            }
            else
            {
                throw new ArgumentNullException("Param:bollist is null!");
            }
        }

        public MultiselectTransformObject(List<bool> bollist, MultiselectTransformObject t):this(bollist)
        {
            t.GetType();
        }

        private char[] BolTransformBinary(List<bool> bollist)
        {
            //get '1' or '0' by bool
            char[] chararray = new char[bollist.Count];
            for (int i = 0; i < bollist.Count; i++)
            {
                chararray[i] = bollist[i] ? '1' : '0';
            }
            return chararray;
        }

        private int BinaryTransformInt(bool bolIndexDesc)
        {
            char[] chararray = BolTransformBinary(_bollist);
            char[] newchararray = new char[chararray.Length];
            chararray.CopyTo(newchararray, 0);

            // "1000"
            // if bolIndexDesc is true , "0001" 
            // if bolIndexDesc is false , "1000" 
            if (bolIndexDesc)
            {
                #region This is he he da!
                //for (int i = 0; i < chararray.Length; i++)
                //{
                //    if (i != chararray.Length / 2)
                //    {
                //        chararray[i] = (char)((int)chararray[i] + (int)chararray[chararray.Length - i - 1]);
                //        chararray[chararray.Length - i - 1] = (char)((int)chararray[i] - (int)chararray[chararray.Length - i - 1]);
                //        chararray[i] = (char)((int)chararray[i] - (int)chararray[chararray.Length - i - 1]);
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}
                #endregion

                for (int i = chararray.Length - 1; i >= 0; i--)
                {
                    newchararray[chararray.Length - i - 1] = chararray[i];
                }
            }

            int intmode = Convert.ToInt32(new string(newchararray), 2);

            return intmode;
        }

        //invoke method by index
        private void InvokeBySwitch(int index, ref object e)
        {
            foreach (var item in this._methodlist)
            {
                if (item.Key == index)
                {
                    item.Value.Invoke(ref e);
                }
            }
        }

        //add method in list
        protected bool AddMethod(int index, _delmethod method)
        {
            if (!this._methodlist.ContainsKey(index) && method != null)
            {
                this._methodlist.Add(index, method);
            }

            return false;
        }

        //remove method in list
        protected bool RemoveMethod(int index)
        {
            if (this._methodlist.ContainsKey(index))
            {
                this._methodlist.Remove(index);
            }

            return false;
        }

        /// <summary>
        /// Transform and Invoke By Switch
        /// </summary>
        /// <param name="e">return info</param>
        /// <param name="bolIndexDesc">true is default</param>
        public void Transform(ref object e, bool bolIndexDesc = true)
        {
            InvokeBySwitch(BinaryTransformInt(bolIndexDesc), ref e);
        }

    }
}
