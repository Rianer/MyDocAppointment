require('karma-jasmine-html-reporter'),
require('karma-coverage-istanbul-reporter'),
require('@angular-devkit/build-angular/plugins/karma'),
require('karma-sonarqube-reporter')

module.exports = (config) => {
    const coverage = config.singleRun ? ['coverage'] : [];
  
    config.set({
		frameworks: [
		'jasmine',
		],
		plugins: [
		'karma-jasmine',
		'karma-webpack',
		'karma-coverage',
		'karma-remap-istanbul',
		'karma-chrome-launcher',
		],
		files: [
		'./src/tests.entry.ts',
		{
			pattern: '**/*.map',
			served: true,
			included: false,
			watched: true,
		},
		],
		preprocessors: {
		'./src/tests.entry.ts': [
			'webpack',
			'sourcemap',
		],
		'./src/**/!(*.test|tests.*).(ts|js)': [
			'sourcemap',
		],
		},

		webpack: {
		plugins,
		entry: './src/tests.entry.ts',
		devtool: 'inline-source-map',
		resolve: {
			extensions: ['.webpack.js', '.web.js', '.ts', '.js'],
		},
		module: {
			rules:
			combinedLoaders().concat(
				config.singleRun
				? [ loaders.istanbulInstrumenter ]
				: [ ]),
		},
		stats: { colors: true, reasons: true },
		},
		webpackServer: {
		noInfo: true, // prevent console spamming when running in Karma!
		},

		reporters: ['progress', 'kjhtml', 'sonarqube']
		.concat(coverage)
		.concat(coverage.length > 0 ? ['karma-remap-istanbul'] : []),

		remapIstanbulReporter: {
			src: 'coverage/chrome/coverage-final.json',
			reports: {
				html: 'coverage',
			},
		},
		sonarqubeReporter: {
            basePath: 'src/app', // test files folder
            filePattern: '**/*spec.ts', // test files glob pattern
            encoding: 'utf-8', // test files encoding
            outputFolder: 'reports', // report destination
            legacyMode: false, // report for Sonarqube < 6.2 (disabled)
            reportName: function (metadata) {
                // report name callback, but accepts also a
                // string (file name) to generate a single file
                /**
                 * Report metadata array:
                 * - metadata[0] = browser name
                 * - metadata[1] = browser version
                 * - metadata[2] = plataform name
                 * - metadata[3] = plataform version
                 */
                return 'sonarqube_report.xml';
            },
        },

		coverageReporter: {
            reporters: [
                { type: 'json' },
            ],
            dir: './coverage/',
            subdir: (browser) => {
                return browser.toLowerCase().split(/[ /-]/)[0]; // returns 'chrome'
            },
        },

		port: 9999,
		browsers: ['Chrome'],
		colors: true,
		logLevel: config.LOG_INFO,
		autoWatch: true,
		captureTimeout: 6000,
	});
  };

