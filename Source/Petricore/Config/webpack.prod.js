const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const autoprefixer = require('autoprefixer');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
	entry: [
		'./App/licensingAdministration.js',
		'font-awesome-loader',
		'bootstrap-loader/extractStyles'
	],

	output: {
		filename: '[name].js',
		path: './Public',
		publicPath: './',
		hash: true
	},

	sassLoader: { includePaths: ['./Style'] },
	devtool: 'source-map',

	module: {
		loaders: [
			{ test: /\.css$/, loader: ExtractTextPlugin.extract('style', 'css!postcss') },
			{ test: /\.scss$/, loader: ExtractTextPlugin.extract('style', 'css?sourceMap!postcss!sass?sourceMap') },
			{ test: /\.jpe?g$|\.gif$|\.png$/, loader: "file" },
			{ test: /\.woff2?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url" },
			{ test: /\.(ttf|eot|svg)(\?[\s\S]+)?$/, loader: 'file' },
			{ test: /bootstrap-sass\/assets\/javascripts\//, loader: 'imports?jQuery=jquery' },
		]
	},

	plugins: [
		new webpack.optimize.OccurenceOrderPlugin(),
		new webpack.ProvidePlugin({ $: "jquery", jQuery: "jquery" }),
		new ExtractTextPlugin('[name].css'),
		new webpack.optimize.UglifyJsPlugin({ minimize: true }),
		new HtmlWebpackPlugin({
			filename: 'index.html',
			template: './Markup/index.html',
			title: 'PetriCore',
			hash: true,
			inject: true,
			minify: {
				removeComments: true,
				collapseWhitespace: true
			}
		}),
		new webpack.DefinePlugin({
			'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV)
		})
	],

	postcss: [
		autoprefixer({
			browsers: ['last 2 versions']
		})
	],

	devServer: {
		contentBase: './Public',
		historyApiFallback: false,
		host: 'localhost',
		hot: false,
		port: 8001
	}
};