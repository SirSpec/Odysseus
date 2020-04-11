const webpack = require('../webpack.config.js');

module.exports = {
    stories: ['../src/**/*.stories.[tj]s[x]'],
    webpackFinal: (config) => {
        return { ...config, module: { ...config.module, rules: webpack.module.rules } };
    },
};