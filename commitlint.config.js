module.exports = {
    parserPreset: {
        parserOpts: {
            headerPattern: /^([A-Z]+-\d+)\s\|\s([A-Za-z]+)\s\|\s(.+)$/,
            headerCorrespondence: ['ticket', 'type', 'subject'],
        },
    },
    rules: {
        'subject-empty': [2, 'never'],
        'type-enum': [
            2,
            'always',
            ['FixingBug', 'ImplementFeature', 'Refactor', 'Docs']
        ]
    }
};
