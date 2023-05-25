import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import mkcert from 'vite-plugin-mkcert'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        vue(),
        mkcert()
    ],
    commonjsOptions: {
        esmExternals: true
    },
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '/app-users': {
                target: 'https://localhost:44380/api/v1.0',
                changeOrigin: true
              }
        },
        https: true,
        origin: 'https://localhost:44380'
    },
})
