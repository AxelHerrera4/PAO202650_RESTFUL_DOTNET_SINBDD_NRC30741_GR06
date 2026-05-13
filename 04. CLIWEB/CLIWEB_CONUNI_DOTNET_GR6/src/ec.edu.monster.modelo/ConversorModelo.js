export const API_BASE = '/api/Conversor'

export const OPERACIONES_LONGITUD = [
  { code: 'km_m', label: 'Kilometros a Metros', method: 'KmAMetros', param: 'kilometros' },
  { code: 'm_cm', label: 'Metros a Centimetros', method: 'MetrosACm', param: 'metros' },
  { code: 'in_cm', label: 'Pulgadas a Centimetros', method: 'PulgadasACm', param: 'pulgadas' },
  { code: 'ft_m', label: 'Pies a Metros', method: 'PiesAMetros', param: 'pies' },
  { code: 'mi_km', label: 'Millas a Kilometros', method: 'MillasAKm', param: 'millas' },
]

export const OPERACIONES_MASA = [
  { code: 'kg_g', label: 'Kilogramos a Gramos', method: 'KgAGramos', param: 'kilogramos' },
  { code: 'g_mg', label: 'Gramos a Miligramos', method: 'GramosAMg', param: 'gramos' },
  { code: 'lb_kg', label: 'Libras a Kilogramos', method: 'LibrasAKg', param: 'libras' },
  { code: 'oz_g', label: 'Onzas a Gramos', method: 'OnzasAGramos', param: 'onzas' },
  { code: 't_kg', label: 'Toneladas a Kilogramos', method: 'ToneladasAKg', param: 'toneladas' },
]

export const OPERACIONES_TEMP = [
  { code: 'c_f', label: 'Celsius a Fahrenheit', method: 'CelsiusAFahrenheit', param: 'celsius' },
  { code: 'f_c', label: 'Fahrenheit a Celsius', method: 'FahrenheitACelsius', param: 'fahrenheit' },
  { code: 'c_k', label: 'Celsius a Kelvin', method: 'CelsiusAKelvin', param: 'celsius' },
  { code: 'k_c', label: 'Kelvin a Celsius', method: 'KelvinACelsius', param: 'kelvin' },
]

export function getOperaciones(category) {
  if (category === 'longitud') return OPERACIONES_LONGITUD
  if (category === 'masa') return OPERACIONES_MASA
  return OPERACIONES_TEMP
}
