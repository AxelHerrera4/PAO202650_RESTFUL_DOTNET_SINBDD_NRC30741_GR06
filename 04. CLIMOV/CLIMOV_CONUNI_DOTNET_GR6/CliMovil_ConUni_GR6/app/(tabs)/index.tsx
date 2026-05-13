import React, { useState, useMemo, useEffect } from 'react';
import { Alert } from 'react-native';
import { getOperaciones, validarCredenciales, DEFAULT_WS_URL } from '../../ec.edu.monster.modelo/ConversorModelo';
import { invocarServicio } from '../../ec.edu.monster.controlador/ConversorControlador';
import LoginVista from '../../ec.edu.monster.vista/LoginVista';
import ConversorVista from '../../ec.edu.monster.vista/ConversorVista';

export default function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [category, setCategory] = useState('Temperatura');
  const [valor, setValor] = useState('');
  const [operation, setOperation] = useState('');
  const [resultado, setResultado] = useState('...');
  const [unidadOrigen, setUnidadOrigen] = useState('');
  const [unidadDestino, setUnidadDestino] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [wsUrl, setWsUrl] = useState(DEFAULT_WS_URL);

  const operationsList = useMemo(() => getOperaciones(category), [category]);

  useEffect(() => {
    if (operationsList.length > 0) setOperation(operationsList[0].code);
  }, [operationsList]);

  const handleValorChange = (raw: string) => {
    const normalized = raw.replace(',', '.');
    if (normalized === '' || /^-?\d*\.?\d*$/.test(normalized)) setValor(normalized);
  };

  const handleLogin = () => {
    if (validarCredenciales(username, password)) {
      setIsLoggedIn(true);
      setUsername('');
      setPassword('');
    } else {
      Alert.alert('Error', 'Credenciales incorrectas');
    }
  };

  const handleCategoryChange = (newCategory: string) => {
    setCategory(newCategory);
    setResultado('...');
    setUnidadOrigen('');
    setUnidadDestino('');
  };

  const handleConvert = async () => {
    if (!valor) return Alert.alert('Aviso', 'Ingresa un valor');
    const op = operationsList.find(o => o.code === operation);
    if (!op) return Alert.alert('Error', 'Conversion no disponible');
    try {
      const result = await invocarServicio(wsUrl, op.method, valor);
      setResultado(result);
      setUnidadOrigen(`Origen: ${valor}`);
      setUnidadDestino(`Destino: ${result}`);
    } catch (e) {
      Alert.alert('Error de Conexion', `No se pudo conectar al servidor.\nURL: ${wsUrl}`);
      console.error('Error:', e);
    }
  };

  const handleLimpiar = () => {
    setValor('');
    setResultado('...');
    setUnidadOrigen('');
    setUnidadDestino('');
  };

  if (!isLoggedIn) {
    return (
      <LoginVista
        wsUrl={wsUrl}
        username={username}
        password={password}
        onWsUrlChange={setWsUrl}
        onUsernameChange={setUsername}
        onPasswordChange={setPassword}
        onLogin={handleLogin}
      />
    );
  }

  return (
    <ConversorVista
      category={category}
      operation={operation}
      valor={valor}
      resultado={resultado}
      unidadOrigen={unidadOrigen}
      unidadDestino={unidadDestino}
      operationsList={operationsList}
      onCategoryChange={handleCategoryChange}
      onOperationChange={setOperation}
      onValorChange={handleValorChange}
      onConvert={handleConvert}
      onLimpiar={handleLimpiar}
      onLogout={() => { setIsLoggedIn(false); setValor(''); setResultado('...'); }}
    />
  );
}
