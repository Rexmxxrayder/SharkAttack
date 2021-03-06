using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsBoxEngine {
    public enum Axis { X, Y, Z, W }
    public enum DebugType { NORMAL, WARNING, ERROR }

    #region Nullable vector
    // Nullable Vector
    //public class NVector2 {
    //    public Vector2? vector;

    //    //public static void operator =(NVector2 a, Vector2 b) => a.vector = b;
    //    public static implicit operator Vector2(NVector2 a) => (Vector2)a.vector;
    //    public static implicit operator NVector2(Vector2 a) => new NVector2((Vector2?)a);

    //    public NVector2() {
    //        vector = null;
    //    }

    //    public NVector2(Vector2? vector) {
    //        this.vector = vector;
    //    }

    //    public Vector2 Vector {
    //        get { return (Vector2)vector; }
    //        set { vector = value; }
    //    }

    //    public float x {
    //        get { return Vector.x; }
    //        set { Vector = new Vector2(value, Vector.y); }
    //    }

    //    public float y {
    //        get { return Vector.y; }
    //        set { Vector = new Vector2(Vector.x, value); }
    //    }
    //}
    #endregion

    #region Classes

    public class Nullable<T> where T : struct {
        public T? value;

        public static implicit operator T(Nullable<T> a) => (T)a.value;
        public static implicit operator Nullable<T>(T a) => new Nullable<T>((T?)a);

        public Nullable() {
            value = null;
        }

        public Nullable(T? value) {
            this.value = value;
        }

        public T Value {
            get { return (T)value; }
            set { this.value = value; }
        }
    }

    [Serializable]
    public class AmplitudeCurve {
        public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public float duration = 1f;
        public float amplitude = 1f;

        float timer;

        public float Timer => timer;
        public float Percentage => Mathf.Clamp01(timer / duration);

        #region Constructeurs

        public AmplitudeCurve(AnimationCurve curve, float duration, float timer, float amplitude) {
            this.curve = curve;
            this.duration = duration;
            this.timer = timer;
            this.amplitude = amplitude;
        }

        public AmplitudeCurve(AnimationCurve curve) : this(curve, 1f, 0f, 1f) { }

        public AmplitudeCurve() : this(AnimationCurve.Linear(0f, 0f, 1f, 1f)) { }

        public AmplitudeCurve Clone() {
            return new AmplitudeCurve(curve, duration, timer, amplitude);
        }

        #endregion

        public float Evaluate() {
            float ratio = Percentage;
            ratio = curve.Evaluate(ratio);
            return ratio;
        }

        public void UpdateTimer(float deltaTime) {
            timer += deltaTime;
            timer = Mathf.Clamp(timer, 0f, duration);
        }

        public void Reset() {
            timer = 0f;
        }

        public void SetPercentage(float percentage) {
            percentage = Mathf.Clamp01(percentage);
            timer = percentage * duration;
        }
    }

    #endregion

    public static class Tools {
        #region Variables
        static string[] _hurlable = {
            "Hello world ?",
            "Gino", "HERE !", "HURL", "Yellow submarine", "Did you see ?!",
            "REEEEEEEX !", "Imotep", "Ninja !", "Urgh", "Oh la belle bleue", "Ooba ooba !",
            "404", "You're teapot", "Pouet", "Bogo sorted", "Hey listen", "Pourquoi ?",
            "Mr.Gé1enormSecs", "Roblox36", "Achtung", "SirLynixVanFrietjes", "1337", "35383773",
            "Chaussette", "Avez-vous déjà vous ?", "2319", "Viva l'algérie", "C'est une menace ?",
            "Km²/h", "Skribbl ?", "Tools.Print", "Debug.Log", "HURLABLE !", "Malibu coco ?",
            "Papillon de lumière", "How dare u ?", "THIS IS C# !", "On s'en bat les couilles",
            "Connard", "(tousse)", "J'ai mal", "Elle est bonne", "Tamer", "Wingardium", "Wait",
            "C'est ma b*te", "Do a barell roll", "Titre", "Mundo go this way", "Ok", "Enormimus !",
            "Kowabunga", "Ptdr t ki ?", "Pasteque !", "Hein ?", "...", "You really need me ?",
            "T'en veux encore ?", "AÏE", "OUÏLLE", "(Adrien's noise)", "Moule", "Dublin, duh", "DUH",
            "Tartes à la framboise ?", "Chibrons", "UwU", "<color=red>ERRO-</color> nah joking",
            "Papush", "T'as fetch ?", "Derrière toi !", "Phillipe !", "Fifo le fifou", "Va sucer un ours",
            "Mange tes morts", "Peepoodo", "Peekaboo", "Lapinue", "+1", "Apple suxx", "Hit Billy & drink milk",
            "THIIIICK", "Hippity hoppity", "Scoobi-dooby-doo", "Sluuuurp", "Leave me alone", "F*CK YOU !",
            "Leblanc", "2b || !2b", "Boob", "Bark", "Fus Roh Dah", "Push Roh Dah !", "Git Rekt", "Merge tes morts",
            "Bring me egg", "Patatozilla", "La bougie.. M*rde !",
            "Goodbye world"
        };
        #endregion

        #region Delegates

        public delegate void BasicDelegate();

        public delegate void BasicDelegate<T>(T arg);

        //public delegate void BasicDelegateTwoArgs<T>(ref T arg1, T arg2);

        public delegate void BasicDelegate<T1, T2>(T1 arg1, T2 arg2);

        public delegate void BasicDelegate<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

        public delegate T BasicDelegateReturn<T>(T arg);

        public delegate T2 BasicDelegateReturn<T1, T2>(T1 arg);

        #endregion

        #region Extensions methods

        #region Vectors

        public static Vector2 To2D(this Vector3 vector, Axis axisToIgnore = Axis.Z) {
            switch (axisToIgnore) {
                case Axis.X:
                    return new Vector2(vector.y, vector.z);
                case Axis.Y:
                    return new Vector2(vector.x, vector.z);
                case Axis.Z:
                    return new Vector2(vector.x, vector.y);
                default:
                    return new Vector2(vector.x, vector.y);
            }
        }

        public static Vector2Int To2D(this Vector3Int vector, Axis axisToIgnore = Axis.Z) {
            switch (axisToIgnore) {
                case Axis.X:
                    return new Vector2Int(vector.y, vector.z);
                case Axis.Y:
                    return new Vector2Int(vector.x, vector.z);
                case Axis.Z:
                    return new Vector2Int(vector.x, vector.y);
                default:
                    return new Vector2Int(vector.x, vector.y);
            }
        }

        public static Vector3 To3D(this Vector2 vector, float value = 0f, Axis axis = Axis.Z) {
            switch (axis) {
                case Axis.X:
                    return new Vector3(value, vector.x, vector.y);
                case Axis.Y:
                    return new Vector3(vector.x, value, vector.y);
                case Axis.Z:
                    return new Vector3(vector.x, vector.y, value);
                default:
                    return new Vector3(vector.x, vector.y, value);
            }
        }

        public static Vector3Int To3D(this Vector2Int vector, int value = 0, Axis axis = Axis.Z) {
            switch (axis) {
                case Axis.X:
                    return new Vector3Int(value, vector.x, vector.y);
                case Axis.Y:
                    return new Vector3Int(vector.x, value, vector.y);
                case Axis.Z:
                    return new Vector3Int(vector.x, vector.y, value);
                default:
                    return new Vector3Int(vector.x, vector.y, value);
            }
        }

        public static Vector3 To3D(this Vector4 vector, Axis axisToIgnore = Axis.W) {
            switch (axisToIgnore) {
                case Axis.X:
                    return new Vector3(vector.y, vector.z, vector.w);
                case Axis.Y:
                    return new Vector3(vector.x, vector.z, vector.w);
                case Axis.Z:
                    return new Vector3(vector.x, vector.y, vector.w);
                case Axis.W:
                    return new Vector3(vector.x, vector.y, vector.z);
                default:
                    return new Vector3(vector.x, vector.y, vector.z);
            }
        }

        public static Vector3 Override(this Vector3 vector, float value, Axis axis = Axis.Y) {
            switch (axis) {
                case Axis.X:
                    vector.x = value;
                    break;
                case Axis.Y:
                    vector.y = value;
                    break;
                case Axis.Z:
                    vector.z = value;
                    break;
                default:
                    vector.y = value;
                    break;
            }

            return vector;
        }

        public static Vector3 Override(this Vector3 vector, Vector3 target, params Axis[] axis) {
            if (axis.Length <= 0) { return vector; }
            for (int i = 0; i < axis.Length; i++) {
                switch (axis[i]) {
                    case Axis.X:
                        vector = vector.Override(target.x, Axis.X);
                        break;
                    case Axis.Y:
                        vector = vector.Override(target.y, Axis.Y);
                        break;
                    case Axis.Z:
                        vector = vector.Override(target.z, Axis.Z);
                        break;
                }
            }
            return vector;
        }

        public static Vector2 Override(this Vector2 vector, float value, Axis axis = Axis.Y) {
            switch (axis) {
                case Axis.X:
                    vector.x = value;
                    break;
                case Axis.Y:
                    vector.y = value;
                    break;
                case Axis.Z:
                    Debug.LogWarning("Can't override Vector2 z axis, using default axis : y");
                    vector.y = value;
                    break;
                default:
                    vector.y = value;
                    break;
            }

            return vector;
        }

        public static Vector2 Override(this Vector2 vector, Vector2 target, params Axis[] axis) {
            if (axis.Length <= 0) { return vector; }
            for (int i = 0; i < axis.Length; i++) {
                switch (axis[i]) {
                    case Axis.X:
                        vector.Override(target.x, Axis.X);
                        break;
                    case Axis.Y:
                        vector.Override(target.y, Axis.Y);
                        break;
                }
            }
            return vector;
        }

        public static Vector2Int FloorToInt(this Vector2 vector) {
            return new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
        }
        
        public static Vector2 Abs(this Vector2 vector) {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        public static Vector3 Positive(this Vector3 vector) {
            return new Vector3(vector.x.Positive(), vector.y.Positive(), vector.z.Positive());
        }

        public static Vector3 Positive(this Vector3 vector, Axis axis) {
            switch (axis) {
                case Axis.X:
                    vector.x = vector.x.Positive();
                    break;
                case Axis.Y:
                    vector.y = vector.y.Positive();
                    break;
                case Axis.Z:
                    vector.z = vector.z.Positive();
                    break;
            }
            return vector;
        }

        public static Vector3 MultiplyIndividually(this Vector3 vector1, Vector3 vector2) {
            return new Vector3(vector1.x * vector2.x, vector1.y * vector2.y, vector1.z * vector2.z);
        }

        #endregion

        public static Vector2 Position2D(this Transform transform) {
            return transform.position.To2D();
        }

        public static int Find(this int[] array, int value) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == value) {
                    return i;
                }
            }
            return -1;
        }

        public static float Positive(this float number) {
            if (number < 0) {
                number = 0;
            }
            return number;
        }

        public static T[] ToArray<T>(this Nullable<T>[] array) where T : struct {
            T[] returnBack = new T[array.Length];
            for (int i = 0; i < array.Length; i++) {
                returnBack[i] = array[i].Value;
            }
            return returnBack;
        }

        public static Nullable<T>[] ToNullableArray<T>(this T[] array) where T : struct {
            Nullable<T>[] returnBack = new Nullable<T>[array.Length];
            for (int i = 0; i < array.Length; i++) {
                returnBack[i] = (Nullable<T>)array[i];
            }
            return returnBack;
        }

        public static List<T> ToList<T>(this List<Nullable<T>> list) where T : struct {
            List<T> returnBack = new List<T>();
            for (int i = 0; i < list.Count; i++) {
                returnBack.Add(list[i].Value);
            }
            return returnBack;
        }

        public static T2[] Individually<T1, T2>(this T1[] array, BasicDelegateReturn<T1, T2> function) { // Apply a function (with 1 argument) to an Array
            T2[] result = new T2[array.Length];
            for (int i = 0; i < array.Length; i++) {
                result[i] = function(array[i]);
            }
            return result;
        }

        public static Vector3 Redirect(this Vector3 vector, Vector3 direction) {
            float angle = Vector3.SignedAngle(vector, direction, Vector3.up);
            return Quaternion.AngleAxis(angle, Vector3.up) * vector;
        }

        public static Vector3 Redirect(this Vector3 vector, Vector3 firstDirection, Vector3 lastDirection) {
            float angle = Vector3.SignedAngle(firstDirection, lastDirection, Vector3.up);
            return Quaternion.AngleAxis(angle, Vector3.up) * vector;
        }

        public static bool Contains(this LayerMask layerMask, int layer) {
            return layerMask == (layerMask | (1 << layer));
        }

        public static bool IsInside(this float number, float min, float max) {
            if (number > min && number < max) {
                return true;
            }
            return false;
        }

        public static T Random<T>(this T[] array) {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public static bool Contains<T>(this T[] array, T value) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i].Equals(value)) {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Utilities

        public static float Remap(this float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static float InverseLerpUnclamped(float a, float b, float t) {
            //if (b - a == 0) { throw new DivideByZeroException(); }
            if (b - a == 0) { return 1f; }
            float value = (t - a) / (b - a);
            return value;
        }

        public static Rect GetPlayerRect(int playerId, int maxPlayer) {
            switch (maxPlayer) {
                case 1:
                    return new Rect(0, 0, 1, 1);
                case 2:
                    switch (playerId) {
                        case 1:
                            return new Rect(0, 0.5f, 1, 0.5f);
                        case 2:
                            return new Rect(0, 0, 1, 0.5f);
                    }
                    break;
                case 3:
                    switch (playerId) {
                        case 1:
                            return new Rect(0, 0.5f, 0.5f, 0.5f);
                        case 2:
                            return new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                        case 3:
                            return new Rect(0, 0, 0.5f, 0.5f);
                    }
                    break;
                case 4:
                    switch (playerId) {
                        case 1:
                            return new Rect(0, 0.5f, 0.5f, 0.5f);
                        case 2:
                            return new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                        case 3:
                            return new Rect(0, 0, 0.5f, 0.5f);
                        case 4:
                            return new Rect(0.5f, 0, 0.5f, 0.5f);
                    }
                    break;
            }
            return new Rect(0, 0, 1, 1);
        }

        public static float AcuteAngle(float angle) {
            if (angle > 180f) {
                angle = angle - 360f;
            }

            return angle;
        }

        public static Vector3 AcuteAngle(Vector3 angle) {
            return new Vector3(AcuteAngle(angle.x), AcuteAngle(angle.y), AcuteAngle(angle.z));
        }

        public static int Ponder(params float[] weight) {
            float totWeight = 0;

            for (int i = 0; i < weight.Length; i++) {
                totWeight += weight[i];
            }

            if (totWeight < 1f) {
                totWeight = 1f;
            }

            float random = UnityEngine.Random.Range(0, totWeight);

            for (int i = 0; i < weight.Length; i++) {
                if (random < weight[i]) {
                    return i;
                }
                random -= weight[i];
            }

            return -1;
        }

        /// <summary>
        /// Return a random number from argument
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static float RandomFloat(params float[] numbers) {
            int rand = UnityEngine.Random.Range(0, numbers.Length);
            return numbers[rand];
        }

        public static void SerializeInterface<T1, T2>(ref T2 input, ref T1 dummy) where T1 : class where T2 : class {
            if (dummy is T2) {
                input = dummy as T2;
            } else {
                dummy = null;
            }
        }

        public static T RandomValue<T>(params T[] values) {
            int index = UnityEngine.Random.Range(0, values.Length);
            return values[index];
        }

        #endregion

        #region Print

        public static void Print(DebugType type, char separator, params object[] strings) {
            Action<object> debug;
            switch (type) {
                case DebugType.WARNING:
                    debug = Debug.LogWarning;
                    break;
                case DebugType.ERROR:
                    debug = Debug.LogError;
                    break;
                default:
                    debug = Debug.Log;
                    break;
            }
            string output = "";
            for (int i = 0; i < strings.Length - 1; i++) {
                output += strings[i].ToString();
                output += " " + separator + " ";
            }
            output += strings[strings.Length - 1].ToString();
            if (output == "") { return; }
            debug(output);
        }

        public static void Print(DebugType type = DebugType.NORMAL, params object[] strings) {
            Print(type, '.', strings);
        }

        public static void Print(params object[] strings) {
            Print(DebugType.NORMAL, '.', strings);
        }

        public static void Print(char separator, params object[] strings) {
            Print(DebugType.NORMAL, separator, strings);
        }

        public static void Hurl<T>(this T hurler, DebugType type = DebugType.NORMAL) where T : UnityEngine.Object {
            string hurl = _hurlable.Random();
            hurler.Hurl(hurl, type);
        }

        public static void Hurl<T>(this T hurler, string message, DebugType type = DebugType.NORMAL) where T : UnityEngine.Object {
            Print(type, "<b>" + hurler.name + "</b> hurled at you : <b>" + message + "</b>");
        }

        #endregion

        public static IEnumerator Delay<T1, T2, T3>(BasicDelegate<T1, T2, T3> function, T1 arg1, T2 arg2, T3 arg3, float time) {
            yield return new WaitForSeconds(time);
            function(arg1, arg2, arg3);
        }

        public static IEnumerator Delay<T1, T2>(BasicDelegate<T1, T2> function, T1 arg1, T2 arg2, float time) {
            yield return new WaitForSeconds(time);
            function(arg1, arg2);
        }

        public static IEnumerator Delay<T>(BasicDelegate<T> function, T arg, float time) {
            yield return new WaitForSeconds(time);
            function(arg);
        }

        public static IEnumerator Delay(BasicDelegate function, float time) {
            yield return new WaitForSeconds(time);
            function();
        }
    }

    public class ReadOnlyAttribute : PropertyAttribute {

    }
}