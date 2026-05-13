import { API_BASE } from '../ec.edu.monster.modelo/ConversorModelo.js'

export async function invocarServicio(method, valor) {
  const res = await fetch(`${API_BASE}/${method}/${valor}`)
  if (!res.ok) throw new Error(`HTTP Error: ${res.status}`)
  const text = await res.text()
  const num = parseFloat(text)
  if (isNaN(num)) throw new Error(`Respuesta inesperada: ${text}`)
  return num.toFixed(2)
}

export function validarCredenciales(username, password) {
  return username === 'monster' && password === 'monster9'
}
