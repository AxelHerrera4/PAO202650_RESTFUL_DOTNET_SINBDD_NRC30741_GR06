import React, { useState, useMemo, useEffect } from 'react';
import { StyleSheet, Text, View, TextInput, TouchableOpacity, Alert, ScrollView } from 'react-native';
import { Picker } from '@react-native-picker/picker';

// =========================================================================
// CONFIGURACIÓN: Verifica tu IP con 'ipconfig' en la terminal.
// Si estás en la universidad, la IP puede cambiar cada vez que te conectas.
// =========================================================================
const DEFAULT_WS_URL = 'http://localhost:8090';

const OPERACIONES_TEMP_LIST = [
  { code: 'c_f', label: 'Celsius a Fahrenheit', method: 'CelsiusAFahrenheit', param: 'celsius' },
  { code: 'c_k', label: 'Celsius a Kelvin', method: 'CelsiusAKelvin', param: 'celsius' },
  { code: 'f_c', label: 'Fahrenheit a Celsius', method: 'FahrenheitACelsius', param: 'fahrenheit' },
  { code: 'f_k', label: 'Fahrenheit a Kelvin', method: 'FahrenheitAKelvin', param: 'fahrenheit' },
  { code: 'k_c', label: 'Kelvin a Celsius', method: 'KelvinACelsius', param: 'kelvin' },
  { code: 'k_f', label: 'Kelvin a Fahrenheit', method: 'KelvinAFahrenheit', param: 'kelvin' }
];

const OPERACIONES_LONGITUD_LIST = [
  { code: 'km_m', label: 'Kilometros a Metros', method: 'KmAMetros', param: 'kilometros' },
  { code: 'm_cm', label: 'Metros a Centimetros', method: 'MetrosACm', param: 'metros' },
  { code: 'in_cm', label: 'Pulgadas a Centimetros', method: 'PulgadasACm', param: 'pulgadas' },
  { code: 'ft_m', label: 'Pies a Metros', method: 'PiesAMetros', param: 'pies' },
  { code: 'mi_km', label: 'Millas a Kilometros', method: 'MillasAKm', param: 'millas' }
];

const OPERACIONES_MASA_LIST = [
  { code: 'kg_g', label: 'Kilogramos a Gramos', method: 'KgAGramos', param: 'kilogramos' },
  { code: 'g_mg', label: 'Gramos a Miligramos', method: 'GramosAMg', param: 'gramos' },
  { code: 'lb_kg', label: 'Libras a Kilogramos', method: 'LibrasAKg', param: 'libras' },
  { code: 'oz_g', label: 'Onzas a Gramos', method: 'OnzasAGramos', param: 'onzas' },
  { code: 't_kg', label: 'Toneladas a Kilogramos', method: 'ToneladasAKg', param: 'toneladas' }
];

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

  const operationsList = useMemo(() => {
    if (category === 'Temperatura') return OPERACIONES_TEMP_LIST;
    if (category === 'Longitud') return OPERACIONES_LONGITUD_LIST;
    if (category === 'Masa') return OPERACIONES_MASA_LIST;
    return [];
  }, [category]);

  useEffect(() => {
    if (operationsList.length > 0) setOperation(operationsList[0].code);
  }, [operationsList]);

  const handleValorChange = (raw: string) => {
    const normalized = raw.replace(',', '.');
    if (normalized === '' || /^-?\d*\.?\d*$/.test(normalized)) setValor(normalized);
  };

  const handleLogin = () => {
    if (username === 'monster' && password === 'monster9') {
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

  const calcularREST = async () => {
    if (!valor) return Alert.alert("Aviso", "Ingresa un valor");

    const op = operationsList.find(o => o.code === operation);
    if (!op) return Alert.alert("Error", "Conversión no disponible");

    const url = `${wsUrl}/api/Conversor/${op.method}/${valor}`;

    try {
      const response = await fetch(url, { method: "GET" });

      if (!response.ok) {
        throw new Error(`HTTP ${response.status}`);
      }

      const rawValue = await response.text();
      const resultValue = parseFloat(rawValue).toFixed(2);

      if (!isNaN(parseFloat(rawValue))) {
        setResultado(resultValue);
        setUnidadOrigen(`Origen: ${valor}`);
        setUnidadDestino(`Destino: ${resultValue}`);
      } else {
        setResultado('Error de Datos');
        Alert.alert("Error", `Respuesta inesperada: ${rawValue}`);
      }
    } catch (e) {
      Alert.alert("Error de Conexión", `No se pudo conectar al servidor.\nURL: ${wsUrl}`);
      console.error("Error:", e);
    }
  };

  const handleVolver = () => {
    setIsLoggedIn(false);
    setValor('');
    setResultado('...');
  };

  const handleLimpiar = () => {
    setValor('');
    setResultado('...');
    setUnidadOrigen('');
    setUnidadDestino('');
  };

  if (!isLoggedIn) {
    return (
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.heroSection}>
          <Text style={styles.title}>ConUni</Text>
          <Text style={styles.subtitle}>Conversor Universal (RESTful)</Text>
        </View>
        <View style={styles.loginCard}>
          <Text style={styles.loginTitle}>Iniciar Sesión</Text>
          <Text style={styles.label}>URL del Servidor:</Text>
          <TextInput 
            style={styles.input} 
            placeholder="http://192.168.1.12:62638/Service1.svc" 
            value={wsUrl} 
            onChangeText={setWsUrl}
          />
          <TextInput style={styles.input} placeholder="Usuario" value={username} onChangeText={setUsername} />
          <TextInput style={styles.input} placeholder="Contraseña" secureTextEntry value={password} onChangeText={setPassword} />
          <TouchableOpacity style={styles.loginButton} onPress={handleLogin}>
            <Text style={styles.buttonText}>ACCEDER</Text>
          </TouchableOpacity>
        </View>
      </ScrollView>
    );
  }

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.headerSection}>
        <Text style={styles.title}>ConUni</Text>
        <Text style={styles.subtitle}>{category.toUpperCase()}</Text>
      </View>

      <View style={styles.categorySelector}>
        {['Temperatura', 'Longitud', 'Masa'].map((cat) => (
          <TouchableOpacity
            key={cat}
            style={[styles.categoryBtn, category === cat && styles.activeCategoryBtn]}
            onPress={() => handleCategoryChange(cat)}
          >
            <Text style={styles.categoryBtnText}>{cat}</Text>
          </TouchableOpacity>
        ))}
      </View>

      <View style={styles.card}>
        <Text style={styles.label}>Operación:</Text>
        <Picker selectedValue={operation} onValueChange={setOperation} style={styles.picker}>
          {operationsList.map(op => (
            <Picker.Item key={op.code} label={op.label} value={op.code} />
          ))}
        </Picker>

        <TextInput
          style={styles.input}
          placeholder="0.00"
          keyboardType="numeric"
          value={valor}
          onChangeText={handleValorChange}
        />

        <View style={styles.resultBox}>
          <Text style={styles.resValue}>{resultado}</Text>
          <Text style={styles.resUnit}>{unidadOrigen}</Text>
          <Text style={styles.resUnit}>{unidadDestino}</Text>
        </View>

        <View style={styles.buttonRow}>
          <TouchableOpacity style={styles.button} onPress={calcularREST}>
            <Text style={styles.buttonText}>CONVERTIR</Text>
          </TouchableOpacity>
          <TouchableOpacity style={[styles.button, styles.buttonSecondary]} onPress={handleLimpiar}>
            <Text style={styles.buttonText}>LIMPIAR</Text>
          </TouchableOpacity>
        </View>

        <TouchableOpacity style={styles.logoutButton} onPress={handleVolver}>
          <Text style={styles.buttonText}>SALIR</Text>
        </TouchableOpacity>
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: { flexGrow: 1, backgroundColor: '#0f172a', alignItems: 'center', paddingVertical: 50, paddingHorizontal: 20 },
  title: { fontSize: 42, color: '#60a5fa', fontWeight: 'bold' },
  subtitle: { fontSize: 18, color: '#bfdbfe', marginBottom: 20 },
  heroSection: { alignItems: 'center', marginBottom: 30 },
  loginCard: { width: '100%', backgroundColor: '#f8fafc', padding: 25, borderRadius: 15 },
  loginTitle: { fontSize: 22, fontWeight: 'bold', marginBottom: 20, textAlign: 'center' },
  input: { backgroundColor: '#e2e8f0', padding: 15, borderRadius: 10, fontSize: 16, marginBottom: 15, color: '#1e293b' },
  loginButton: { backgroundColor: '#2563eb', padding: 15, borderRadius: 10, alignItems: 'center' },
  buttonText: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
  headerSection: { alignItems: 'center', marginBottom: 20 },
  categorySelector: { flexDirection: 'row', gap: 10, marginBottom: 20 },
  categoryBtn: { flex: 1, padding: 12, backgroundColor: '#334155', borderRadius: 10, alignItems: 'center' },
  activeCategoryBtn: { backgroundColor: '#2563eb' },
  categoryBtnText: { color: '#fff', fontWeight: 'bold' },
  card: { width: '100%', backgroundColor: '#f8fafc', padding: 25, borderRadius: 15 },
  label: { fontWeight: 'bold', color: '#475569', marginBottom: 5 },
  picker: { backgroundColor: '#e2e8f0', marginBottom: 15 },
  resultBox: { backgroundColor: '#f1f5f9', padding: 20, borderRadius: 10, marginVertical: 20, alignItems: 'center', borderWidth: 1, borderColor: '#cbd5e1' },
  resValue: { fontSize: 32, fontWeight: 'bold', color: '#0f172a' },
  resUnit: { fontSize: 14, color: '#64748b' },
  buttonRow: { flexDirection: 'row', gap: 10 },
  button: { flex: 1, backgroundColor: '#2563eb', padding: 15, borderRadius: 10, alignItems: 'center' },
  buttonSecondary: { backgroundColor: '#64748b' },
  logoutButton: { marginTop: 15, padding: 15, alignItems: 'center' },
});