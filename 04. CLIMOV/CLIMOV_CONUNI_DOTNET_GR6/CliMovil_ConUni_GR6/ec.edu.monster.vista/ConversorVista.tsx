import React from 'react';
import { View, Text, TextInput, TouchableOpacity, ScrollView, StyleSheet } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import { Operacion } from '../ec.edu.monster.modelo/ConversorModelo';

interface Props {
  category: string;
  operation: string;
  valor: string;
  resultado: string;
  unidadOrigen: string;
  unidadDestino: string;
  operationsList: Operacion[];
  onCategoryChange: (cat: string) => void;
  onOperationChange: (op: string) => void;
  onValorChange: (v: string) => void;
  onConvert: () => void;
  onLimpiar: () => void;
  onLogout: () => void;
}

export default function ConversorVista({
  category, operation, valor, resultado, unidadOrigen, unidadDestino, operationsList,
  onCategoryChange, onOperationChange, onValorChange, onConvert, onLimpiar, onLogout
}: Props) {
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
            onPress={() => onCategoryChange(cat)}
          >
            <Text style={styles.categoryBtnText}>{cat}</Text>
          </TouchableOpacity>
        ))}
      </View>

      <View style={styles.card}>
        <Text style={styles.label}>Operacion:</Text>
        <Picker selectedValue={operation} onValueChange={onOperationChange} style={styles.picker}>
          {operationsList.map(op => (
            <Picker.Item key={op.code} label={op.label} value={op.code} />
          ))}
        </Picker>

        <TextInput
          style={styles.input}
          placeholder="0.00"
          keyboardType="numeric"
          value={valor}
          onChangeText={onValorChange}
        />

        <View style={styles.resultBox}>
          <Text style={styles.resValue}>{resultado}</Text>
          <Text style={styles.resUnit}>{unidadOrigen}</Text>
          <Text style={styles.resUnit}>{unidadDestino}</Text>
        </View>

        <View style={styles.buttonRow}>
          <TouchableOpacity style={styles.button} onPress={onConvert}>
            <Text style={styles.buttonText}>CONVERTIR</Text>
          </TouchableOpacity>
          <TouchableOpacity style={[styles.button, styles.buttonSecondary]} onPress={onLimpiar}>
            <Text style={styles.buttonText}>LIMPIAR</Text>
          </TouchableOpacity>
        </View>

        <TouchableOpacity style={styles.logoutButton} onPress={onLogout}>
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
  headerSection: { alignItems: 'center', marginBottom: 20 },
  categorySelector: { flexDirection: 'row', gap: 10, marginBottom: 20 },
  categoryBtn: { flex: 1, padding: 12, backgroundColor: '#334155', borderRadius: 10, alignItems: 'center' },
  activeCategoryBtn: { backgroundColor: '#2563eb' },
  categoryBtnText: { color: '#fff', fontWeight: 'bold' },
  card: { width: '100%', backgroundColor: '#f8fafc', padding: 25, borderRadius: 15 },
  label: { fontWeight: 'bold', color: '#475569', marginBottom: 5 },
  picker: { backgroundColor: '#e2e8f0', marginBottom: 15 },
  input: { backgroundColor: '#e2e8f0', padding: 15, borderRadius: 10, fontSize: 16, marginBottom: 15, color: '#1e293b' },
  resultBox: { backgroundColor: '#f1f5f9', padding: 20, borderRadius: 10, marginVertical: 20, alignItems: 'center', borderWidth: 1, borderColor: '#cbd5e1' },
  resValue: { fontSize: 32, fontWeight: 'bold', color: '#0f172a' },
  resUnit: { fontSize: 14, color: '#64748b' },
  buttonRow: { flexDirection: 'row', gap: 10 },
  button: { flex: 1, backgroundColor: '#2563eb', padding: 15, borderRadius: 10, alignItems: 'center' },
  buttonSecondary: { backgroundColor: '#64748b' },
  logoutButton: { marginTop: 15, padding: 15, alignItems: 'center', backgroundColor: '#334155', borderRadius: 10 },
  buttonText: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
});
