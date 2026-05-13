import React from 'react';
import { View, Text, TextInput, TouchableOpacity, ScrollView, StyleSheet } from 'react-native';

interface Props {
  wsUrl: string;
  username: string;
  password: string;
  onWsUrlChange: (v: string) => void;
  onUsernameChange: (v: string) => void;
  onPasswordChange: (v: string) => void;
  onLogin: () => void;
}

export default function LoginVista({ wsUrl, username, password, onWsUrlChange, onUsernameChange, onPasswordChange, onLogin }: Props) {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.heroSection}>
        <Text style={styles.title}>ConUni</Text>
        <Text style={styles.subtitle}>Conversor Universal (RESTful)</Text>
      </View>
      <View style={styles.loginCard}>
        <Text style={styles.loginTitle}>Iniciar Sesion</Text>
        <Text style={styles.label}>URL del Servidor:</Text>
        <TextInput
          style={styles.input}
          placeholder="http://192.168.1.x:8090"
          value={wsUrl}
          onChangeText={onWsUrlChange}
        />
        <TextInput
          style={styles.input}
          placeholder="Usuario"
          value={username}
          onChangeText={onUsernameChange}
        />
        <TextInput
          style={styles.input}
          placeholder="Contrasena"
          secureTextEntry
          value={password}
          onChangeText={onPasswordChange}
        />
        <TouchableOpacity style={styles.loginButton} onPress={onLogin}>
          <Text style={styles.buttonText}>ACCEDER</Text>
        </TouchableOpacity>
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: { flexGrow: 1, backgroundColor: '#0f172a', alignItems: 'center', paddingVertical: 50, paddingHorizontal: 20 },
  heroSection: { alignItems: 'center', marginBottom: 30 },
  title: { fontSize: 42, color: '#60a5fa', fontWeight: 'bold' },
  subtitle: { fontSize: 18, color: '#bfdbfe', marginBottom: 20 },
  loginCard: { width: '100%', backgroundColor: '#f8fafc', padding: 25, borderRadius: 15 },
  loginTitle: { fontSize: 22, fontWeight: 'bold', marginBottom: 20, textAlign: 'center' },
  label: { fontWeight: 'bold', color: '#475569', marginBottom: 5 },
  input: { backgroundColor: '#e2e8f0', padding: 15, borderRadius: 10, fontSize: 16, marginBottom: 15, color: '#1e293b' },
  loginButton: { backgroundColor: '#2563eb', padding: 15, borderRadius: 10, alignItems: 'center' },
  buttonText: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
});
