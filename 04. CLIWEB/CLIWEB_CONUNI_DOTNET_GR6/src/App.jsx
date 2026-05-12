import { useState } from 'react'
import './App.css'

const API_BASE = '/api/Conversor'

const OPERACIONES_LONGITUD = [
  { code: 'km_m', label: 'Kilometros a Metros', method: 'KmAMetros', param: 'kilometros' },
  { code: 'm_cm', label: 'Metros a Centimetros', method: 'MetrosACm', param: 'metros' },
  { code: 'in_cm', label: 'Pulgadas a Centimetros', method: 'PulgadasACm', param: 'pulgadas' },
  { code: 'ft_m', label: 'Pies a Metros', method: 'PiesAMetros', param: 'pies' },
  { code: 'mi_km', label: 'Millas a Kilometros', method: 'MillasAKm', param: 'millas' },
]

const OPERACIONES_MASA = [
  { code: 'kg_g', label: 'Kilogramos a Gramos', method: 'KgAGramos', param: 'kilogramos' },
  { code: 'g_mg', label: 'Gramos a Miligramos', method: 'GramosAMg', param: 'gramos' },
  { code: 'lb_kg', label: 'Libras a Kilogramos', method: 'LibrasAKg', param: 'libras' },
  { code: 'oz_g', label: 'Onzas a Gramos', method: 'OnzasAGramos', param: 'onzas' },
  { code: 't_kg', label: 'Toneladas a Kilogramos', method: 'ToneladasAKg', param: 'toneladas' },
]

const OPERACIONES_TEMP = [
  { code: 'c_f', label: 'Celsius a Fahrenheit', method: 'CelsiusAFahrenheit', param: 'celsius' },
  { code: 'f_c', label: 'Fahrenheit a Celsius', method: 'FahrenheitACelsius', param: 'fahrenheit' },
  { code: 'c_k', label: 'Celsius a Kelvin', method: 'CelsiusAKelvin', param: 'celsius' },
  { code: 'k_c', label: 'Kelvin a Celsius', method: 'KelvinACelsius', param: 'kelvin' },
]

async function invokeRest(method, valor) {
  const res = await fetch(`${API_BASE}/${method}/${valor}`)
  if (!res.ok) throw new Error(`HTTP Error: ${res.status}`)
  const text = await res.text()
  const num = parseFloat(text)
  if (isNaN(num)) throw new Error(`Respuesta inesperada: ${text}`)
  return num.toFixed(2)
}

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [loginError, setLoginError] = useState('')
  const [category, setCategory] = useState('longitud')
  const [opCode, setOpCode] = useState(OPERACIONES_LONGITUD[0].code)
  const [valor, setValor] = useState('')
  const [resultado, setResultado] = useState(null)
  const [unidadOrigen, setUnidadOrigen] = useState('')
  const [unidadDestino, setUnidadDestino] = useState('')
  
  const operations = category === 'longitud' ? OPERACIONES_LONGITUD : category === 'masa' ? OPERACIONES_MASA : OPERACIONES_TEMP

  const handleLogin = (event) => {
    event.preventDefault()
    if (username === 'monster' && password === 'monster9') {
      setIsLoggedIn(true)
      setLoginError('')
      return
    }
    setLoginError('Credenciales inválidas')
  }

const handleConvert = async () => {
    if (!valor) return;
    
    // Buscamos la operación en la lista que corresponde a la categoría actual
    const op = operations.find(o => o.code === opCode);

    // Verificación de seguridad:
    if (!op) {
      setResultado('Error: Seleccione una operación válida');
      return;
    }

    try {
      const r = await invokeRest(op.method, valor);
      setResultado(r);
      setUnidadOrigen(`Origen: ${valor}`);
      setUnidadDestino(`Resultado: ${r}`);
    } catch (e) {
      setResultado('Error de conexión');
      console.error(e);
    }
  };

  const handleValorChange = (raw) => {
    const v = raw.replace(',', '.')
    if (v === '' || /^-?\d*\.?\d*$/.test(v)) {
      setValor(v)
    }
  }

  if (!isLoggedIn) {
    return (
      <div className="desktop-shell login-shell">
        <div className="login-layout">
          <section className="login-hero">
            <h1>MONSTER</h1>
            <h2>Sistema de Conversion RESTful</h2>
            <p>Temperatura, Masa y Longitud en una interfaz profesional.</p>
            <span>Acceso protegido ESPE - GR06</span>
          </section>

          <form className="login-panel" onSubmit={handleLogin}>
            <h3>Iniciar sesion</h3>
            <label>
              Usuario
              <input value={username} onChange={(e) => setUsername(e.target.value)} />
            </label>
            <label>
              Contraseña
              <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
            </label>
            {loginError && <div className="error-text">{loginError}</div>}
            <div className="login-actions">
              <button type="submit" className="primary-btn">Ingresar</button>
            </div>
          </form>
        </div>
      </div>
    )
  }

  return (
    <div className="desktop-shell">
      <div className="desktop-window">
        <header className="window-header">
          <h1>CONVERSOR MONSTER | {category.toUpperCase()}</h1>
        </header>

        <main className="converter-card">
          <label className="field-label">Categoría</label>
          <select className="field-input" value={category} onChange={(e) => {
            setCategory(e.target.value)
            setResultado(null)
          }}>
            <option value="temperatura">Temperatura</option>
            <option value="longitud">Longitud</option>
            <option value="masa">Masa</option>
          </select>

          <label className="field-label">Operación</label>
          <select className="field-input" value={opCode} onChange={e => setOpCode(e.target.value)}>
            {operations.map(op => (
              <option key={op.code} value={op.code}>{op.label}</option>
            ))}
          </select>

          <label className="field-label">Valor</label>
          <input className="field-input" value={valor} onChange={e => handleValorChange(e.target.value)} placeholder="0.00" />

          <section className="result-box">
            <strong>{resultado ?? '---'}</strong>
            <p>{unidadOrigen}</p>
            <p>{unidadDestino}</p>
          </section>

          <div className="buttons-grid">
            <button className="primary-btn" onClick={handleConvert}>Convertir</button>
            <button className="secondary-btn" onClick={() => { setValor(''); setResultado(null); }}>Limpiar</button>
            <button className="secondary-btn" onClick={() => setIsLoggedIn(false)}>Cerrar Sesión</button>
          </div>
        </main>
      </div>
    </div>
  )
}

export default App