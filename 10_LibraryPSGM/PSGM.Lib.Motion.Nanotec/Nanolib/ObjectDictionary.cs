//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Nlc {

    public class ObjectDictionary : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal ObjectDictionary(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectDictionary obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~ObjectDictionary()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NanolibPINVOKE.delete_ObjectDictionary(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
            }
        }

        public ObjectDictionary() : this(NanolibPINVOKE.new_ObjectDictionary(), true)
        {
        }

        public virtual ResultString getXmlFileName()
        {
            ResultString ret = new ResultString(NanolibPINVOKE.ObjectDictionary_getXmlFileName(swigCPtr), true);
            return ret;
        }

        public virtual ResultDeviceHandle getDeviceHandle()
        {
            ResultDeviceHandle ret = new ResultDeviceHandle(NanolibPINVOKE.ObjectDictionary_getDeviceHandle(swigCPtr), true);
            return ret;
        }

        public virtual ResultObjectSubEntry getObject(Nlc.OdIndex odIndex)
        {
            ResultObjectSubEntry ret = new ResultObjectSubEntry(NanolibPINVOKE.ObjectDictionary_getObject(swigCPtr, odIndex), true);
            return ret;
        }

        public virtual ResultObjectEntry getObjectEntry(ushort index)
        {
            ResultObjectEntry ret = new ResultObjectEntry(NanolibPINVOKE.ObjectDictionary_getObjectEntry(swigCPtr, index), true);
            return ret;
        }

        public virtual ResultInt readNumber(Nlc.OdIndex odIndex)
        {
            ResultInt ret = new ResultInt(NanolibPINVOKE.ObjectDictionary_readNumber(swigCPtr, odIndex), true);
            return ret;
        }

        public virtual ResultString readString(Nlc.OdIndex odIndex)
        {
            ResultString ret = new ResultString(NanolibPINVOKE.ObjectDictionary_readString(swigCPtr, odIndex), true);
            return ret;
        }

        public virtual ResultArrayByte readBytes(Nlc.OdIndex odIndex)
        {
            ResultArrayByte ret = new ResultArrayByte(NanolibPINVOKE.ObjectDictionary_readBytes(swigCPtr, odIndex), true);
            return ret;
        }

        public virtual ResultVoid writeNumber(Nlc.OdIndex odIndex, long value)
        {
            ResultVoid ret = new ResultVoid(NanolibPINVOKE.ObjectDictionary_writeNumber(swigCPtr, odIndex, value), true);
            return ret;
        }

        public virtual ResultVoid writeBytes(Nlc.OdIndex odIndex, ByteVector data)
        {
            ResultVoid ret = new ResultVoid(NanolibPINVOKE.ObjectDictionary_writeBytes(swigCPtr, odIndex, ByteVector.getCPtr(data)), true);
            if (NanolibPINVOKE.SWIGPendingException.Pending) throw NanolibPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual ResultArrayInt readNumberArray(ushort index)
        {
            ResultArrayInt ret = new ResultArrayInt(NanolibPINVOKE.ObjectDictionary_readNumberArray(swigCPtr, index), true);
            return ret;
        }



    }
}
