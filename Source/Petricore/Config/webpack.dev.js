const webpack = require('webpack');
const autoprefixer = require('autoprefixer');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
	entry: [
		'webpack-hot-middleware/client',
		'font-awesome-loader',
		'bootstrap-loader',
		'./App/Petricore.js'
	],

	output: {
		filename: '[name].js',
		path: './Public'
	},

	sassLoader: { includePaths: ['./Style'] },
	devtool: '#cheap-module-eval-source-map',
	watch: true,

	module: {
		loaders: [
            { test: /\.js?$/, loaders: ['eslint'] },
			{ test: /\.css$/, loaders: ['style', 'css', 'postcss'] },
			{ test: /\.scss$/, loaders: ['style', 'css?sourceMap', 'postcss', 'sass?sourceMap'] },
			{ test: /\.jpe?g$|\.gif$|\.png$/, loader: "file" },
			{ test: /\.woff2?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url" },
			{ test: /\.(ttf|eot|svg)(\?[\s\S]+)?$/, loader: 'file' },
			{ test: /bootstrap-sass\/assets\/javascripts\//, loader: 'imports?jQuery=jquery' }
		]
	},

	plugins: [
		new webpack.optimize.OccurenceOrderPlugin(),
		new webpack.ProvidePlugin({ $: "jquery", jQuery: "jquery" }),
		new webpack.optimize.UglifyJsPlugin({ minimize: false }),
		new webpack.HotModuleReplacementPlugin(),
		new webpack.NoErrorsPlugin(),
		new HtmlWebpackPlugin({
			filename: 'index.html',
			title: 'Petricore',
			template: './Markup/index.html',
			hash: false,
			inject: true
		}),
		new webpack.DefinePlugin({
      'process.env.NODE_ENV': JSON.stringify('development')
    })
	],

	postcss: [
		autoprefixer({
			browsers: ['last 2 versions']
		})
	],

	devServer: {
		contentBase: './Public',
		historyApiFallback: true,
		host: 'localhost',
		hot: true,
		port: 8002,
		stats: { color: true },
		watchOptions: {
			aggregateTimeout: 50
		}
	}
};