export async function invocarServicio(wsUrl: string, method: string, valor: string): Promise<string> {
  const url = `${wsUrl}/api/Conversor/${method}/${valor}`
  const response = await fetch(url, { method: 'GET' })
  if (!response.ok) throw new Error(`HTTP ${response.status}`)
  const rawValue = await response.text()
  const num = parseFloat(rawValue)
  if (isNaN(num)) throw new Error(`Respuesta inesperada: ${rawValue}`)
  return num.toFixed(2)
}
