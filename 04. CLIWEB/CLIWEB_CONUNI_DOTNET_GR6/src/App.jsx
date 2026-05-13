import { useState } from 'react'
import './App.css'
import { getOperaciones, OPERACIONES_LONGITUD } from './ec.edu.monster.modelo/ConversorModelo.js'
import { invocarServicio, validarCredenciales } from './ec.edu.monster.controlador/ConversorControlador.js'
import LoginVista from './ec.edu.monster.vista/LoginVista.jsx'
import ConversorVista from './ec.edu.monster.vista/ConversorVista.jsx'

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

  const handleLogin = (event) => {
    event.preventDefault()
    if (validarCredenciales(username, password)) {
      setIsLoggedIn(true)
      setLoginError('')
      return
    }
    setLoginError('Credenciales invalidas')
  }

  const handleCategoryChange = (newCat) => {
    setCategory(newCat)
    setResultado(null)
    const ops = getOperaciones(newCat)
    setOpCode(ops[0].code)
  }

  const handleValorChange = (raw) => {
    const v = raw.replace(',', '.')
    if (v === '' || /^-?\d*\.?\d*$/.test(v)) setValor(v)
  }

  const handleConvert = async () => {
    if (!valor) return
    const operations = getOperaciones(category)
    const op = operations.find(o => o.code === opCode)
    if (!op) { setResultado('Error: Seleccione una operacion valida'); return }
    try {
      const r = await invocarServicio(op.method, valor)
      setResultado(r)
      setUnidadOrigen(`Origen: ${valor}`)
      setUnidadDestino(`Resultado: ${r}`)
    } catch (e) {
      setResultado('Error de conexion')
      console.error(e)
    }
  }

  if (!isLoggedIn) {
    return (
      <LoginVista
        username={username}
        password={password}
        loginError={loginError}
        onUsernameChange={setUsername}
        onPasswordChange={setPassword}
        onSubmit={handleLogin}
      />
    )
  }

  return (
    <ConversorVista
      category={category}
      opCode={opCode}
      valor={valor}
      resultado={resultado}
      unidadOrigen={unidadOrigen}
      unidadDestino={unidadDestino}
      onCategoryChange={handleCategoryChange}
      onOpCodeChange={setOpCode}
      onValorChange={handleValorChange}
      onConvert={handleConvert}
      onLimpiar={() => { setValor(''); setResultado(null) }}
      onLogout={() => setIsLoggedIn(false)}
    />
  )
}

export default App
