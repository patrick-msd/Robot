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

public class ObjectEntry : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ObjectEntry(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectEntry obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ObjectEntry() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NanolibPINVOKE.delete_ObjectEntry(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public ObjectEntry() : this(NanolibPINVOKE.new_ObjectEntry(), true) {
  }

  public virtual string getName() {
    string ret = NanolibPINVOKE.ObjectEntry_getName(swigCPtr);
    return ret;
  }

  public virtual bool getPrivate() {
    bool ret = NanolibPINVOKE.ObjectEntry_getPrivate(swigCPtr);
    return ret;
  }

  public virtual ushort getIndex() {
    ushort ret = NanolibPINVOKE.ObjectEntry_getIndex(swigCPtr);
    return ret;
  }

  public virtual ObjectEntryDataType getDataType() {
    ObjectEntryDataType ret = (ObjectEntryDataType)NanolibPINVOKE.ObjectEntry_getDataType(swigCPtr);
    return ret;
  }

  public virtual ObjectCode getObjectCode() {
    ObjectCode ret = (ObjectCode)NanolibPINVOKE.ObjectEntry_getObjectCode(swigCPtr);
    return ret;
  }

  public virtual ObjectSaveable getObjectSaveable() {
    ObjectSaveable ret = (ObjectSaveable)NanolibPINVOKE.ObjectEntry_getObjectSaveable(swigCPtr);
    return ret;
  }

  public virtual byte getMaxSubIndex() {
    byte ret = NanolibPINVOKE.ObjectEntry_getMaxSubIndex(swigCPtr);
    return ret;
  }

  public virtual ObjectSubEntry getSubEntry(byte subIndex) {
    ObjectSubEntry ret = new ObjectSubEntry(NanolibPINVOKE.ObjectEntry_getSubEntry(swigCPtr, subIndex), false);
    return ret;
  }

    }

}
