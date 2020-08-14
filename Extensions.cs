﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using Random = UnityEngine.Random;

public static class Extensions
{
	#region STRUCTS
	public static byte[] ToByteArray<T>(this T structure) where T : struct
	{
		var bufferSize = Marshal.SizeOf(structure);
		var byteArray = new byte[bufferSize];

		IntPtr handle = Marshal.AllocHGlobal(bufferSize);
		try
		{
			Marshal.StructureToPtr(structure, handle, true);
			Marshal.Copy(handle, byteArray, 0, bufferSize);

		}
		finally
		{
			Marshal.FreeHGlobal(handle);
		}
		return byteArray;
	}
	public static T BuildFrom<T>(this T structure, byte[] bytes) where T : struct
	{
		var bufferSize = Marshal.SizeOf(typeof(T));
		var handle = Marshal.AllocHGlobal(bufferSize);

		Marshal.Copy(bytes, 0, handle, bufferSize);

		var returnVal = Marshal.PtrToStructure<T>(handle);

		Marshal.FreeHGlobal(handle);

		return returnVal;
	}
	#endregion



	#region TRANSFORM
	public static Vector3 TransformPointUnscaled(this Transform transform, Vector3 position)
	{
		var localToWorldMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
		return localToWorldMatrix.MultiplyPoint3x4(position);
	}

	public static Vector3 InverseTransformPointUnscaled(this Transform transform, Vector3 position)
	{
		var worldToLocalMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one).inverse;
		return worldToLocalMatrix.MultiplyPoint3x4(position);
	}

	public static Transform Reset(this Transform transform)
	{
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		transform.localScale = Vector3.one;
		return transform;
	}

	public static void ZeroAll(this Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localRotation = Quaternion.identity;
		t.localScale = Vector3.one;
	}

	public static void ZeroPosRot(this Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localRotation = Quaternion.identity;
	}
	#endregion



	#region GETCREATE
	public static T GetCreateComponent<T>(this MonoBehaviour c) where T : UnityEngine.Component
	{
		return c.gameObject.GetCreateComponent<T>();
	}

	public static T GetCreateComponent<T>(this GameObject go) where T : UnityEngine.Component
	{
		T comp = go.GetComponent<T>();
		if (comp == null)
			comp = go.AddComponent<T>();
		return comp;
	}

	public static T GetCreateComponent<T>(this Transform t) where T : UnityEngine.Component
	{
		return t.gameObject.GetCreateComponent<T>();
	}
	public static T GetCreateComponent<T>(this Component t) where T : UnityEngine.Component
	{
		return t.gameObject.GetCreateComponent<T>();
	}
	#endregion



	#region RANDOM
	public static T GetRandom<T>(this IList<T> list)
	{
		if (list == null || list.Count <= 0)
		{
			return default(T);
		}
		return list[Random.Range(0, list.Count)];
	}

	public static T GetRandom<T>(this T[] list)
	{
		if (list == null || list.Length <= 0)
		{
			return default(T);
		}
		return list[Random.Range(0, list.Length)];
	}
	#endregion
}
