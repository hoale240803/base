module.exports = {
    parserPreset: {
        parserOpts: {
            headerPattern: /^([A-Z]+-\d+)\s\|\s([A-Za-z]+)\s\|\s(.+)$/,
            headerCorrespondence: ['ticket', 'type', 'subject'],
        },
    },
    rules: {
        'header-pattern': [2, 'always', /^([A-Z]+-\d+)\s\|\s([A-Za-z]+)\s\|\s(.+)$/],
        'type-enum': [2, 'always', ['FixingBug', 'ImplementFeature', 'Refactor', 'Docs', 'Test', 'Chore']],
        'subject-empty': [2, 'never'],
    },
};
