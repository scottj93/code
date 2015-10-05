module Automation
  class Bootstrap < Thor
    TOOLS_URL = 'http://s3.amazonaws.com/developwithpassion-files/clients/us_able_life/cc.txt'

    include ::Automation::Utils

    namespace :bootstrap

    desc 'setup', 'init the machine'

    method_option :rebuild_db, type: :boolean, default: true
    def setup

      p "entered setup"

      `touch #{settings.timestamps.verification_file}`

      initialize_settings_file

      clean_invoke 'automation:expand'

      unzip_external_tools

      clean_invoke 'nuget:refresh_packages'

    end

    no_commands do
      def clean_invoke(command)
        invoke command, [], {}
      end

      def initialize_settings_file
        clean_invoke 'automation:clean'
      end

      def build_db
        unit = 'compile_units/all.compile'

        run_command_lines({
          title: 'Rebuilding DB'
        }, <<code

thor compile:project #{unit}
thor db:rebuild
thor specs:run_them #{unit} --flags=exclude:slow,seed
thor migrate:migrate #{unit}
thor specs:run_them #{unit}

code
                         )
      end

      def unzip_external_tools
        unless File.exist?('cc.txt')
          run_command_lines({
            title: "Downloading external tools from: #{TOOLS_URL}"
          }, <<code

curl -o cc.txt #{TOOLS_URL}

code
                           )
        end

        run_command_lines({
          title: 'Installing external tools',
        }, <<code

rm -rf cc

rm -rf automation/tools

unzip cc.txt

cp -rf cc/lib/. lib/.

cp -rf cc/automation .

code
                         )
      end
    end
  end
end
