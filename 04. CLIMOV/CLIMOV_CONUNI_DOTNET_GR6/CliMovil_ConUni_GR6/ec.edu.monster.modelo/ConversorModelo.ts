export const DEFAULT_WS_URL = 'http://localhost:8090'

export interface Operacion {
  code: string
  label: string
  method: string
  param: string
}

export const OPERACIONES_TEMP: Operacion[] = [
  { code: 'c_f', label: 'Celsius a Fahrenheit', method: 'CelsiusAFahrenheit', param: 'celsius' },
  { code: 'c_k', label: 'Celsius a Kelvin', method: 'CelsiusAKelvin', param: 'celsius' },
  { code: 'f_c', label: 'Fahrenheit a Celsius', method: 'FahrenheitACelsius', param: 'fahrenheit' },
  { code: 'f_k', label: 'Fahrenheit a Kelvin', method: 'FahrenheitAKelvin', param: 'fahrenheit' },
  { code: 'k_c', label: 'Kelvin a Celsius', method: 'KelvinACelsius', param: 'kelvin' },
  { code: 'k_f', label: 'Kelvin a Fahrenheit', method: 'KelvinAFahrenheit', param: 'kelvin' },
]

export const OPERACIONES_LONGITUD: Operacion[] = [
  { code: 'km_m', label: 'Kilometros a Metros', method: 'KmAMetros', param: 'kilometros' },
  { code: 'm_cm', label: 'Metros a Centimetros', method: 'MetrosACm', param: 'metros' },
  { code: 'in_cm', label: 'Pulgadas a Centimetros', method: 'PulgadasACm', param: 'pulgadas' },
  { code: 'ft_m', label: 'Pies a Metros', method: 'PiesAMetros', param: 'pies' },
  { code: 'mi_km', label: 'Millas a Kilometros', method: 'MillasAKm', param: 'millas' },
]

export const OPERACIONES_MASA: Operacion[] = [
  { code: 'kg_g', label: 'Kilogramos a Gramos', method: 'KgAGramos', param: 'kilogramos' },
  { code: 'g_mg', label: 'Gramos a Miligramos', method: 'GramosAMg', param: 'gramos' },
  { code: 'lb_kg', label: 'Libras a Kilogramos', method: 'LibrasAKg', param: 'libras' },
  { code: 'oz_g', label: 'Onzas a Gramos', method: 'OnzasAGramos', param: 'onzas' },
  { code: 't_kg', label: 'Toneladas a Kilogramos', method: 'ToneladasAKg', param: 'toneladas' },
]

export function getOperaciones(category: string): Operacion[] {
  if (category === 'Temperatura') return OPERACIONES_TEMP
  if (category === 'Longitud') return OPERACIONES_LONGITUD
  if (category === 'Masa') return OPERACIONES_MASA
  return []
}

export function validarCredenciales(username: string, password: string): boolean {
  return username === 'monster' && password === 'monster9'
}
