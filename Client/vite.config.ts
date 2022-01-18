import {defineConfig} from 'vite'
import vue from '@vitejs/plugin-vue'
import * as path from "path";

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [vue()],

    server: {
        host: true,
        fs: {
            strict: false,
            // allow: ['.']
        },
        port: 8081,
        proxy: {
            '^/api': {
                target: 'https://localhost:5001',
                // target: 'http://localhost:5000',
                changeOrigin: true,
                secure: false,
                rewrite: (path) => path.replace(/^\/api/, '/api')
            }
        }
    },
    resolve: {
        alias: {
            '@': `${path.resolve(__dirname, 'src')}`,
            '~@': `${path.resolve(__dirname, 'src')}`,
            '$types': `${path.resolve(__dirname, '../types/')}`
        }
    }


})
