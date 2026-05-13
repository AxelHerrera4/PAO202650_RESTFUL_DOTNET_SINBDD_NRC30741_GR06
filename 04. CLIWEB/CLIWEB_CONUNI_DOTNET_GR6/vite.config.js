export default {
  server: {
    proxy: {
      '/api': {
        target: 'http://10.40.26.222:8090',
        changeOrigin: true,
      },
    },
  },
}