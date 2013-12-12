using System;
using System.Reflection;

namespace Core_MovieShelf.Test
{
    public class ReflectionTestHelper
    {
        const BindingFlags StaticBindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        const BindingFlags InstanceBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

       
		#region Public Methods

		/// <summary>
		///	Runs a static method on a type, given its parameters. This is useful for
		///	calling private or protected methods.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="strMethod"></param>
		/// <param name="objParams"></param>
		/// <returns>The return value of the called method.</returns>
		public static object RunStaticMethod(Type type, string strMethod, object [] objParams)
		{
		    return RunMethod(type, strMethod, null, objParams, StaticBindingFlags);
		}

        /// <summary>
        /// Runs a method on a type, given its parameters. This is useful for
        ///	calling private or protected methods.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="objParams">The obj params.</param>
        /// <returns></returns>
		public static object RunInstanceMethod(Type type, string strMethod, object objInstance, object [] objParams)
		{
		    return RunMethod(type, strMethod, objInstance, objParams, InstanceBindingFlags);
		}

        /// <summary>
        /// Gets the static property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static object GetStaticProperty(Type type, string strMethod, object[] index)
        {
            return GetProperty(type, strMethod, null, StaticBindingFlags, index);
        }

        /// <summary>
        /// Gets the instance property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static object GetInstanceProperty(Type type, string strMethod, object objInstance, object[] index)
        {
            return GetProperty(type, strMethod, objInstance, InstanceBindingFlags, index);
        }
        /// <summary>
        /// Sets the static property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="setValue">The set value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static object SetStaticProperty(Type type, string strMethod, object setValue, object[] index)
        {
            return SetProperty(type, strMethod, null, StaticBindingFlags, setValue, index);
        }

        /// <summary>
        /// Sets the instance property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="setValue">The set value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static object SetInstanceProperty(Type type, string strMethod, object objInstance, object setValue, object[] index)
        {
            return SetProperty(type, strMethod, objInstance, InstanceBindingFlags, setValue, index);
        }

        /// <summary>
        /// Gets the static field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <returns></returns>
        public static object GetStaticField(Type type, string strMethod)
        {
            return GetField(type, strMethod, null, StaticBindingFlags);
        }

        /// <summary>
        /// Gets the instance field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <returns></returns>
        public static object GetInstanceField(Type type, string strMethod, object objInstance)
        {
            return GetField(type, strMethod, objInstance, InstanceBindingFlags);
        }

        /// <summary>
        /// Sets the static field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="setValue">The set value.</param>
        /// <returns></returns>
        public static object SetStaticField(Type type, string strMethod, object setValue)
        {
            return SetField(type, strMethod, null, StaticBindingFlags, setValue);
        }

        /// <summary>
        /// Sets the instance field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="setValue">The set value.</param>
        /// <returns></returns>
        public static object SetInstanceField(Type type, string strMethod, object objInstance, object setValue)
        {
            return SetField(type, strMethod, objInstance, InstanceBindingFlags, setValue);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Runs the method.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="objParams">The obj params.</param>
        /// <param name="eFlags">The e flags.</param>
        /// <returns></returns>
		private static object RunMethod(IReflect type, string strMethod, object objInstance, object [] objParams, BindingFlags eFlags) 
		{
			MethodInfo method;
			try 
			{
                if ((eFlags == InstanceBindingFlags) && (objInstance == null))
                {
                    throw new ArgumentException("The reflection non-static object argument was invalid");
                }
                if ((eFlags == StaticBindingFlags) && (objInstance != null))
                {
                    throw new ArgumentException("The reflection static object argument was invalid");
                }
               
			    if ((objInstance != null) && (objInstance.GetType() != (Type)type) && (objInstance.GetType().BaseType != (Type)type))
			    {
			        throw new ArgumentException("The object instance was of type '" + objInstance.GetType() + "' for type '" + type + "'.");
			    }
			    if (string.IsNullOrEmpty(strMethod))
                {
                    throw new ArgumentException("The reflection method argument was invalid");
                }
                method = type.GetMethod(strMethod, eFlags);
                if (method == null)
				{
                    throw new ArgumentException("There is no method '" + strMethod + "' for type '" + type + "'.");
				}

                var objRet = method.Invoke(objInstance, objParams);
				return objRet;
			}
			catch (Exception exception)
			{
                Console.WriteLine(exception.Message);
                throw;
			}
		}

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="eFlags">The e flags.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static object GetProperty(IReflect type, string strMethod, object objInstance, BindingFlags eFlags, object[] index)
        {
            PropertyInfo property;
            try
            {
                if ((eFlags == InstanceBindingFlags) && (objInstance == null))
                {
                    throw new ArgumentException("The reflection non-static object argument was invalid");
                }
                if ((eFlags == StaticBindingFlags) && (objInstance != null))
                {
                    throw new ArgumentException("The reflection static object argument was invalid");
                }
                if ((objInstance != null) && (objInstance.GetType() != (Type)type) && (objInstance.GetType().BaseType != (Type)type))
                {
                    throw new ArgumentException("The object instance was of type '" + objInstance.GetType() + "' for type '" + type + "'.");
                }
                if (string.IsNullOrEmpty(strMethod))
                {
                    throw new ArgumentException("The reflection method argument was invalid");
                }
                property = type.GetProperty(strMethod, eFlags);
                if (property == null)
                {
                    throw new ArgumentException("There is no property '" + strMethod + "' for type '" + type + "'.");
                }

                var objRet = property.GetValue(objInstance, index);
                return objRet;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="eFlags">The e flags.</param>
        /// <param name="setValue">The set value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static object SetProperty(IReflect type, string strMethod, object objInstance, BindingFlags eFlags, object setValue, object[] index)
        {
            PropertyInfo property;
            try
            {
                if ((eFlags == InstanceBindingFlags) && (objInstance == null))
                {
                    throw new ArgumentException("The reflection non-static object argument was invalid");
                }
                if ((eFlags == StaticBindingFlags) && (objInstance != null))
                {
                    throw new ArgumentException("The reflection static object argument was invalid");
                }
                if ((objInstance != null) && (objInstance.GetType() != (Type)type) && (objInstance.GetType().BaseType != (Type)type))
                {
                    throw new ArgumentException("The object instance was of type '" + objInstance.GetType() + "' for type '" + type + "'.");
                }
                if (string.IsNullOrEmpty(strMethod))
                {
                    throw new ArgumentException("The reflection method argument was invalid");
                }
                property = type.GetProperty(strMethod, eFlags);
                if (property == null)
                {
                    throw new ArgumentException("There is no property '" + strMethod + "' for type '" + type + "'.");
                }
                if (setValue.GetType() != property.PropertyType)
                {
                    throw new ArgumentException("The value instance was of type '" + setValue.GetType() + "' for field type '" + property.PropertyType + "'.");
                }

                property.SetValue(objInstance, setValue, index);
                var objRet = property.GetValue(objInstance, index);
                return objRet;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="eFlags">The e flags.</param>
        /// <returns></returns>
        private static object GetField(IReflect type, string strMethod, object objInstance, BindingFlags eFlags)
        {
            FieldInfo field;
            try
            {
                if ((eFlags == InstanceBindingFlags) && (objInstance == null))
                {
                    throw new ArgumentException("The reflection non-static object argument was invalid");
                }
                if ((eFlags == StaticBindingFlags) && (objInstance != null))
                {
                    throw new ArgumentException("The reflection static object argument was invalid");
                }
                if ((objInstance != null) && (objInstance.GetType() != (Type)type) && (objInstance.GetType().BaseType != (Type)type))
                {
                    throw new ArgumentException("The object instance was of type '" + objInstance.GetType() + "' for type '" + type + "'.");
                }
                if (string.IsNullOrEmpty(strMethod))
                {
                    throw new ArgumentException("The reflection method argument was invalid");
                }
                 field = type.GetField(strMethod, eFlags);
                if (field == null)
                {
                    throw new ArgumentException("There is no field '" + strMethod + "' for type '" + type + "'.");
                }

                var objRet = field.GetValue(objInstance);
                return objRet;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="strMethod">The STR method.</param>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="eFlags">The e flags.</param>
        /// <param name="setValue">The set value.</param>
        /// <returns></returns>
        private static object SetField(IReflect type, string strMethod, object objInstance, BindingFlags eFlags, object setValue)
        {
            FieldInfo field;
            try
            {
                if ((eFlags == InstanceBindingFlags) && (objInstance == null))
                {
                    throw new ArgumentException("The reflection non-static object argument was invalid");
                }
                if ((eFlags == StaticBindingFlags) && (objInstance != null))
                {
                    throw new ArgumentException("The reflection static object argument was invalid");
                }
                if ((objInstance != null) && (objInstance.GetType() != (Type)type) && (objInstance.GetType().BaseType != (Type)type))
                {
                    throw new ArgumentException("The object instance was of type '" + objInstance.GetType() + "' for type '" + type + "'.");
                }
                if (string.IsNullOrEmpty(strMethod))
                {
                    throw new ArgumentException("The reflection method argument was invalid");
                }

                field = type.GetField(strMethod, eFlags);
                if (field == null)
                {
                    throw new ArgumentException("There is no field '" + strMethod + "' for type '" + type + "'.");
                }

                if (setValue.GetType() != field.FieldType)
                {
                    throw new ArgumentException("The value instance was of type '" + setValue.GetType() + "' for field type '" + field.FieldType + "'.");
                }
                
                field.SetValue(objInstance, setValue);
                var objRet = field.GetValue(objInstance);
                return objRet;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
		#endregion

	} 

}
