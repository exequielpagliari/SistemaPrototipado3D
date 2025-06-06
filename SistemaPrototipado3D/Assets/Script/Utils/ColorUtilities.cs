using UnityEngine;

/// <summary>
/// Provee m�todos de utilidad est�ticos relacionados con colores.
/// </summary>
public static class ColorUtilities
{
    /// <summary>
    /// Genera un color aleatorio con componentes R, G, B y A (Alpha) completos.
    /// </summary>
    /// <returns>Un objeto Color aleatorio.</returns>
    public static Color GetRandomColor()
    {
        // Random.value devuelve un float entre 0.0 y 1.0 (ambos inclusive).
        // Se usa para cada componente de color (Rojo, Verde, Azul, Alpha).
        return new Color(
            Random.value,  // Componente Rojo
            Random.value,  // Componente Verde
            Random.value,  // Componente Azul
            1f             // Componente Alpha (opacidad total)
        );
    }

    /// <summary>
    /// Genera un color aleatorio con opacidad completa, garantizando
    /// que el color sea perceptiblemente diferente al blanco puro y al negro puro.
    /// Esto ayuda a evitar colores muy oscuros o muy claros que son dif�ciles de ver.
    /// </summary>
    /// <param name="minBrightness">Brillo m�nimo (0.0 a 1.0) para el color.</param>
    /// <param name="maxBrightness">Brillo m�ximo (0.0 a 1.0) para el color.</param>
    /// <param name="minSaturation">Saturaci�n m�nima (0.0 a 1.0) para el color.</param>
    /// <returns>Un objeto Color aleatorio dentro del rango de brillo y saturaci�n especificado.</returns>
    public static Color GetPerceptibleRandomColor(float minBrightness = 0.5f, float maxBrightness = 0.9f, float minSaturation = 0.7f)
    {
        // Aseg�rate de que los rangos sean v�lidos
        minBrightness = Mathf.Clamp01(minBrightness);
        maxBrightness = Mathf.Clamp01(maxBrightness);
        minSaturation = Mathf.Clamp01(minSaturation);

        // Genera un tono (Hue) aleatorio (0.0 a 1.0)
        float hue = Random.value;
        // Genera saturaci�n y valor (brillo) dentro de los rangos especificados
        float saturation = Random.Range(minSaturation, 1f);
        float value = Random.Range(minBrightness, maxBrightness);

        // Convierte HSV a RGB
        return Color.HSVToRGB(hue, saturation, value);
    }
}